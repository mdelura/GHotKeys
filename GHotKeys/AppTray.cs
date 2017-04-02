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
            _notifyIcon.Visible = true;
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip menuStrip = new ContextMenuStrip();
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

        void Exit_Click(object sender, EventArgs e) => Application.Exit();
    }
}
