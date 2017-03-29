using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GHotKeys
{
    [Flags]
    public enum KeyModifier
    {
        None = 0x0000,
        Alt = 0x0001,
        Ctrl = 0x0002,
        NoRepeat = 0x4000,
        Shift = 0x0004,
        Win = 0x0008
    }

    class Hotkey
    {
        public const int WmHotKey = 0x0312;

        private KeyModifier _modifiers;
        private Keys _key;
        private IntPtr _hWnd;
        private int _id;

        public Hotkey(KeyModifier modifiers, Keys key, Form handlerForm)
        {
            _modifiers = modifiers;
            _key = key;
            _hWnd = handlerForm.Handle;
            _id = GetHashCode();
        }

        public bool Register() => RegisterHotKey(_hWnd, _id, (UInt32)_modifiers, (UInt32)_key);

        public bool Unregister() => UnregisterHotKey(_hWnd, _id);

        public override int GetHashCode() => (int)_modifiers ^ (int)_key ^ _hWnd.ToInt32();

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}