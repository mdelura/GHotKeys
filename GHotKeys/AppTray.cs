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

        List<Hotkey> _hotkeys = new List<Hotkey>();
        List<KeySenderForm> _keySenderForms = new List<KeySenderForm>(); 

        bool _isHotkeysWindowLoaded = false;
        bool _isAboutLoaded = false;

        public AppTray()
        {
            InitializeNotifyIcon();
            InitializeHotkeys();
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

        private void InitializeHotkeys()
        {
            //TODO: To be stored outside (serialization)
            HotkeyInfo[] infos = new HotkeyInfo[]
            {
                new HotkeyInfo(KeyModifier.Win, Keys.C, Keys.MediaPlayPause),
                new HotkeyInfo(KeyModifier.Win, Keys.End, Keys.MediaPlayPause),
                new HotkeyInfo(KeyModifier.Win, Keys.PageDown, Keys.MediaNextTrack),
                new HotkeyInfo(KeyModifier.Win, Keys.PageUp, Keys.MediaPreviousTrack),
                new HotkeyInfo(KeyModifier.Win | KeyModifier.Ctrl, Keys.Z, Keys.MediaPlayPause),
                new HotkeyInfo(KeyModifier.Win | KeyModifier.Ctrl, Keys.S, Keys.MediaNextTrack),
                new HotkeyInfo(KeyModifier.Win | KeyModifier.Ctrl, Keys.A, Keys.MediaPreviousTrack),
            };
            //Register hotkeys and add to list if successful.
            foreach (var info in infos)
                RegisterHotkey(info);
        }

        private void ShowHotkeys_Click(object sender, EventArgs e)
        {
            if (!_isHotkeysWindowLoaded)
            {
                _isHotkeysWindowLoaded = true;
                new HotkeysWindow(this).ShowDialog();
                _isHotkeysWindowLoaded = false;
            }
        }

        private void RegisterHotkey_Click(object sender, EventArgs e) => ShowRegisterHotkeyDialog(null);

        private void About_Click(object sender, EventArgs e)
        {
            if (!_isAboutLoaded)
            {
                _isAboutLoaded = true;
                new AboutBox().ShowDialog();
                _isAboutLoaded = false;
            }
        }

        void Exit_Click(object sender, EventArgs e) => Application.Exit();

        private void ShowRegisterHotkeyDialog(HotkeyInfo initial)
        {
            HotkeyInfo registerInfo = RegisterHotkeyForm.ShowHotkeyDialog(initial);
            if (registerInfo != null && !RegisterHotkey(registerInfo))
            {
                if (MessageBox.Show("Unable to register Hotkey:\r\n" + 
                    $"{registerInfo.Modifiers.ToString().Replace(',', '+')} + {registerInfo.Key}\r\n" +
                    "Do you want to try different combination?", "Hotkey registration failed", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    ShowRegisterHotkeyDialog(registerInfo);
            }
        }

        private bool RegisterHotkey(HotkeyInfo hotkeyInfo)
        {
            Hotkey hotkey = new Hotkey(hotkeyInfo, GetHandlerForm(hotkeyInfo));
            bool registered;
            if (registered = hotkey.Register())
            {
                _hotkeys.Add(hotkey);
#if DEBUG
                System.Diagnostics.Debug.Print("{0}\t{1}", hotkey, registered ? "OK" : "Failed to Register");
#endif
            }
            return registered;
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
