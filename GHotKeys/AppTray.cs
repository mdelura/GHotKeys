using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHotKeys
{
    class AppTray : IDisposable
    {
        NotifyIcon _notifyIcon;
        HandleForm _handleForm;
        Hotkey _hotkey;

        public AppTray()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = Properties.Resources.TrayIcon;
            _notifyIcon.Visible = true;

            _handleForm = new HandleForm();

            _hotkey = new Hotkey(KeyModifier.Win | KeyModifier.Ctrl, Keys.Z, _handleForm);
            bool registered = _hotkey.Register();

            System.Diagnostics.Debug.Print(registered ? "Hotkey registration successful" : "Hotkey registration failed");
        }

        public void Dispose()
        {
            _hotkey.Unregister();
            _notifyIcon.Dispose();
            _handleForm.Dispose();
        }

        void Exit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
