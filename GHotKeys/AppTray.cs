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
        KeySenderForm _mediaPlayPauseKeySender;
        KeySenderForm _mediaNextTrackKeySender;
        KeySenderForm _mediaPreviousTrackKeySender;

        bool _isHotkeysWindowLoaded = false;
        bool _isAboutLoaded = false;

        List<Hotkey> _hotkeys = new List<Hotkey>();

        public AppTray()
        {
            InitializeNotifyIcon();
            InitializeKeySenders();
            InitializeHotkeys();
        }

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
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add("About", null, About_Click);
            menuStrip.Items.Add(new ToolStripSeparator());
            menuStrip.Items.Add("Exit", null, Exit_Click);

            return menuStrip;
        }



        private void InitializeKeySenders()
        {
            _mediaPlayPauseKeySender = new KeySenderForm(Keys.MediaPlayPause);
            _mediaNextTrackKeySender = new KeySenderForm(Keys.MediaNextTrack);
            _mediaPreviousTrackKeySender = new KeySenderForm(Keys.MediaPreviousTrack);
        }

        private void InitializeHotkeys()
        {
            //Add hotkeys to a list
            _hotkeys.AddRange(new[]
            {
                //TODO: 
                //Add config to have this configurable (and to be able to check if possible to register)
                //Save settings
                //Check other media keys?
                new Hotkey(KeyModifier.Win, Keys.C, _mediaPlayPauseKeySender),
                new Hotkey(KeyModifier.Win, Keys.End, _mediaPlayPauseKeySender),
                new Hotkey(KeyModifier.Win, Keys.PageDown, _mediaNextTrackKeySender),
                new Hotkey(KeyModifier.Win, Keys.PageUp, _mediaPreviousTrackKeySender),
                new Hotkey(KeyModifier.Win | KeyModifier.Ctrl, Keys.Z, _mediaPlayPauseKeySender),
                new Hotkey(KeyModifier.Win | KeyModifier.Ctrl, Keys.S, _mediaNextTrackKeySender),
                new Hotkey(KeyModifier.Win | KeyModifier.Ctrl, Keys.A, _mediaPreviousTrackKeySender),
            });

            //Register and check if ok
            foreach (var hotkey in _hotkeys)
            {
                bool registered = hotkey.Register();
#if DEBUG
                System.Diagnostics.Debug.Print("{0}\t{1}", hotkey, registered ? "OK" : "Failed to Register");
#endif
            }

        }

        public void Dispose()
        {
            foreach (var hotkey in _hotkeys)
                hotkey.Unregister();

            _mediaPlayPauseKeySender.Dispose();
            _mediaNextTrackKeySender.Dispose();
            _mediaPreviousTrackKeySender.Dispose();

            _notifyIcon.Dispose();
        }

        private void ShowHotkeys_Click(object sender, EventArgs e)
        {
            if (!_isHotkeysWindowLoaded)
            {
                _isHotkeysWindowLoaded = true;
                new HotkeysWindow(_hotkeys).ShowDialog();
                _isHotkeysWindowLoaded = false;
            }
        }

        private void About_Click(object sender, EventArgs e)
        {
            if (!_isAboutLoaded)
            {
                _isAboutLoaded = true;
                new AboutBox().ShowDialog();
                _isAboutLoaded = false;
            }
            

            System.Diagnostics.Debug.Print("Hotkeys count: " + _hotkeys.Count().ToString());
        }

        void Exit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
