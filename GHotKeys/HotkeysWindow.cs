using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHotKeys
{
    internal partial class HotkeysWindow : Form
    {
        public event EventHandler UserDeletingRow;
        AppTray _appTray;

        public HotkeysWindow(AppTray appTray) 
        {
            InitializeComponent();
            Icon = Properties.Resources.TrayIcon;
            _appTray = appTray;
            _hotkeyBindingSource.DataSource = appTray.Hotkeys;
        }

        private void _hotkeysGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is Hotkey)
            {
                Hotkey toBeDeleted = (Hotkey)e.Row.DataBoundItem;
                bool unregistered = toBeDeleted.Unregister();
                UserDeletingRow?.Invoke(sender, e);
#if DEBUG
                System.Diagnostics.Debug.Print("Unregistered:" + unregistered); 
#endif
            }
        }

        private void _registerButton_Click(object sender, EventArgs e)
        {
            _appTray.ShowRegisterHotkeyDialog();
            _hotkeysGridView.DataSource = null;
            _hotkeysGridView.DataSource = _hotkeyBindingSource;
        }
    }
}
