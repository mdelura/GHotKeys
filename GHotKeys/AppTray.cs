using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHotKeys
{
    class AppTray : IDisposable
    {
        const string SavedHotkeysFileName = "hotkeyinfo.bin";


        NotifyIcon _notifyIcon;
        AboutBox _aboutBox;
        HotkeysWindow _hotkeysWindow;

        List<Hotkey> _hotkeys = new List<Hotkey>();
        List<KeySenderForm> _keySenderForms = new List<KeySenderForm>(); 

        public AppTray()
        {
            InitializeNotifyIcon();
            //Check if save file is available
            if (File.Exists(SavedHotkeysFileName))
            {
                HotkeyInfo[] infos = DeserializeHotkeyInfo(SavedHotkeysFileName);
                foreach (var info in infos)
                    RegisterHotkey(info);
            }
        }

        public IEnumerable<Hotkey> Hotkeys => _hotkeys;

        public void Dispose()
        {
            foreach (var hotkey in _hotkeys)
                hotkey.Unregister();

            foreach (var form in _keySenderForms)
                form.Dispose();

            _notifyIcon.Dispose();
        }

        public void ShowRegisterHotkeyDialog() => ShowRegisterHotkeyDialog(null);

        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = Properties.Resources.TrayIcon;
            _notifyIcon.ContextMenuStrip = CreateContextMenu();
            _notifyIcon.DoubleClick += ShowHotkeys_Click;
            _notifyIcon.Visible = true;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            ToolStripMenuItem showHotkeys = new ToolStripMenuItem("Show Hotkeys", null, ShowHotkeys_Click);
            showHotkeys.Font = new Font(showHotkeys.Font, showHotkeys.Font.Style | FontStyle.Bold);
            menuStrip.Items.Add(showHotkeys);
            menuStrip.Items.Add("Register new", null, RegisterHotkey_Click);
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add("About", null, About_Click);
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add("Exit", null, Exit_Click);

            return menuStrip;
        }

        private HotkeyInfo[] DeserializeHotkeyInfo(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = File.OpenRead(fileName))
                return (HotkeyInfo[])formatter.Deserialize(fileStream);
        }

        private void ShowHotkeys_Click(object sender, EventArgs e)
        {
            if (_hotkeysWindow == null || _hotkeysWindow.IsDisposed)
            {
                _hotkeysWindow = new HotkeysWindow(this);
                _hotkeysWindow.UserDeletingRow += (object windowSender, EventArgs windowE) => SaveHotkeys();
                _hotkeysWindow.Show();
            }
            else
            {
                _hotkeysWindow.Activate();
            }
        }

        private void RegisterHotkey_Click(object sender, EventArgs e) => ShowRegisterHotkeyDialog(null);

        private void About_Click(object sender, EventArgs e)
        {
            if (_aboutBox == null || _aboutBox.IsDisposed)
            {
                _aboutBox = new AboutBox();
                _aboutBox.Show();
            }
            else
            {
                _aboutBox.Activate();
            }
        }

        void Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void ShowRegisterHotkeyDialog(HotkeyInfo initial)
        {
            HotkeyInfo registerInfo = RegisterHotkeyForm.ShowHotkeyDialog(initial);
            if (registerInfo != null && !RegisterHotkey(registerInfo, true))
            {
                if (MessageBox.Show("Unable to register Hotkey:\r\n" + 
                    $"{registerInfo.Modifiers.ToString().Replace(',', '+')} + {registerInfo.Key}\r\n" +
                    "Do you want to try different combination?", "Hotkey registration failed", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    ShowRegisterHotkeyDialog(registerInfo);
            }
        }

        private bool RegisterHotkey(HotkeyInfo hotkeyInfo, bool save = false)
        {
            Hotkey hotkey = new Hotkey(hotkeyInfo, GetHandlerForm(hotkeyInfo));
            bool registered;
            if (registered = hotkey.Register())
            {
                _hotkeys.Add(hotkey);
                if (save)
                    SaveHotkeys();
#if DEBUG
                System.Diagnostics.Debug.Print("{0}\t{1}", hotkey, registered ? "OK" : "Failed to Register");
#endif
            }
            return registered;
        }

        private void SaveHotkeys()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream fileStream = File.Create(SavedHotkeysFileName))
                formatter.Serialize(fileStream, _hotkeys.Select(h => h.GetInfo()).ToArray());
        }

        private Form GetHandlerForm(HotkeyInfo registerInfo)
        {
            var handlerForm = _keySenderForms
                .Where(f => f.KeyToSend == registerInfo.Function)
                .SingleOrDefault();

            if (handlerForm == null)
            {
                handlerForm = new KeySenderForm(registerInfo.Function);
                _keySenderForms.Add(handlerForm);
            }
            return handlerForm;
        }
    }
}
