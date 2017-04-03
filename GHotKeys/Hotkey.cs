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

        private IntPtr _hWnd;
        private int _id;

        public Hotkey(KeyModifier modifiers, Keys key, Form handlerForm)
        {
            Modifiers = modifiers;
            Key = key;
            _hWnd = handlerForm.Handle;
            _id = GetHashCode();
            if (handlerForm is KeySenderForm)
                Function = ((KeySenderForm)handlerForm).GetFunction();
        }

        public KeyModifier Modifiers { get; private set; }

        public Keys Key { get; private set; }

        public string Function { get; private set; }


        public bool Register() => RegisterHotKey(_hWnd, _id, (UInt32)Modifiers, (UInt32)Key);

        public bool Unregister() => UnregisterHotKey(_hWnd, _id);

        public override int GetHashCode() => (int)Modifiers ^ (int)Key ^ _hWnd.ToInt32();

        public override string ToString() => $"Modifiers: {Modifiers}, Key: {Key}, Id: {_id}, Handler: {_hWnd}";

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, UInt32 fsModifiers, UInt32 vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}