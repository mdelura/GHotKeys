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
    public partial class KeySenderForm : Form
    {
        public KeySenderForm(Keys keyToSend)
        {
            InitializeComponent();
            KeyToSend = keyToSend;
        }

        public Keys KeyToSend { get; set; }

        public string GetFunction() => KeyToSend.ToString();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkey.WmHotKey)
                NativeMethods.SendKeys(KeyToSend);
            base.WndProc(ref m);
        }
    }
}
