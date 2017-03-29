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
    public partial class HandleForm : Form
    {
        public HandleForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkey.WmHotKey)
                MessageBox.Show("Hotkey pressed");
            base.WndProc(ref m);
        }
    }
}
