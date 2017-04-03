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
    internal partial class HotkeysWindow : Form
    {
        public HotkeysWindow(IList<Hotkey> hotkeys) 
        {
            InitializeComponent();
            _hotkeyBindingSource.DataSource = hotkeys;
        }

        private void _hotkeysGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            System.Diagnostics.Debug.Print("User is about to delete a row");
            if (e.Row.DataBoundItem is Hotkey)
            {
                System.Diagnostics.Debug.Print("Data Bound Item is a hotkey");
                Hotkey toBeDeleted = (Hotkey)e.Row.DataBoundItem;
                bool unregistered = toBeDeleted.Unregister();
                System.Diagnostics.Debug.Print("Unregistered:" + unregistered);
            }
        }

    }
}
