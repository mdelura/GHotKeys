using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;

namespace GHotKeys
{

    [StructLayout(LayoutKind.Sequential)]
    public struct Input
    {
        public int type;
        public InputUnion inputUnion;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        // Fields
        [FieldOffset(0)]
        public HardwareInput hi;
        [FieldOffset(0)]
        public KeyboardInput ki;
        [FieldOffset(0)]
        public MouseInput mi;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public short wVk;
        public short wScan;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int dx;
        public int dy;
        public int mouseData;
        public int dwFlags;
        public int time;
        public IntPtr dwExtraInfo;
    }

    static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendInput(int nInputs, [In] Input[] pInputs,
        int cbSize);


        public static int SendKeys(params Keys[] keys)
        {
            var nativeKeys = keys.Select(
            k => new Input
            {
                type = 1,
                inputUnion = new InputUnion
                {
                    ki = new KeyboardInput { wVk = (short)k }
                }
            }
            ).ToArray();
            int keysSent = SendInput(nativeKeys.Length, nativeKeys,
            Marshal.SizeOf(typeof(Input)));
            if (keysSent == 0) throw new Win32Exception();
            return keysSent;
        }
    }
}
