using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GHotKeys
{
    [Serializable]
    class HotkeyInfo
    {
        public HotkeyInfo(KeyModifier modifiers, Keys key, Keys function)
        {
            Modifiers = modifiers;
            Key = key;
            Function = function;
        }

        public KeyModifier Modifiers { get; private set; }

        public Keys Key { get; private set; }

        public Keys Function { get; private set; }

        public override string ToString() => $"Modifiers: {Modifiers}, Key: {Key}, Function: {Function}";
    }
}
