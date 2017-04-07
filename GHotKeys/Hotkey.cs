using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;

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

        private IntPtr _hWnd;
        private int _id;
        private HotkeyInfo _info;

        public Hotkey(HotkeyInfo info, Form handlerForm)
        {
            _info = info;

            _hWnd = handlerForm.Handle;
            _id = GetHashCode();
        }


        public KeyModifier Modifiers => _info.Modifiers;

        public Keys Key => _info.Key;

        public Keys Function => _info.Function;

        public HotkeyInfo GetInfo() => _info;

        public bool Register() => RegisterHotKey(_hWnd, _id, (UInt32)_info.Modifiers, (UInt32)_info.Key);

        public bool Unregister() => UnregisterHotKey(_hWnd, _id);

        public override int GetHashCode() => (int)_info.Modifiers ^ (int)_info.Key ^ _hWnd.ToInt32();

        public override string ToString() => $"{_info}, Id: {_id}, Handler: {_hWnd}";

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}