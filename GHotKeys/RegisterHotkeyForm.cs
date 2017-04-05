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
    partial class RegisterHotkeyForm : Form
    {
        private List<Keys> _keys;
        private List<Keys> _functions;
        public RegisterHotkeyForm()
        {
            InitializeComponent();
            Icon = Properties.Resources.TrayIcon;
            AssignCheckBoxTags();
            SetCombosDataSources();
        }

        public RegisterHotkeyForm(HotkeyInfo initial) : this()
        {
            var checkedModifiers = initial.Modifiers
                .ToString()
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(strEnum =>
                {
                    KeyModifier outEnum;
                    Enum.TryParse(strEnum, out outEnum);
                    return outEnum;
                });
            foreach (var checkBox in _modifiersGroup.Controls.OfType<CheckBox>())
            {
                if (checkedModifiers.Contains((KeyModifier)checkBox.Tag))
                    checkBox.Checked = true;
            }

            _keyCombo.SelectedItem = initial.Key;
            _functionCombo.SelectedItem = initial.Function;
        }

        public HotkeyInfo HotkeyInfoResult { get; private set; }

        public static HotkeyInfo ShowHotkeyDialog(HotkeyInfo initial = null)
        {
            HotkeyInfo result = null;
            RegisterHotkeyForm registerHotkeyForm;
            if (initial != null)
                registerHotkeyForm = new RegisterHotkeyForm(initial);
            else
                registerHotkeyForm = new RegisterHotkeyForm();

            if (registerHotkeyForm.ShowDialog() == DialogResult.OK)
                result = registerHotkeyForm.HotkeyInfoResult;
            return result;
        }

        private void AssignCheckBoxTags()
        {
            _ctrlCheck.Tag = KeyModifier.Ctrl;
            _altCheck.Tag = KeyModifier.Alt;
            _winCheck.Tag = KeyModifier.Win;
            _shiftCheck.Tag = KeyModifier.Shift;
        }

        private void SetCombosDataSources()
        {
            _keys = ((Keys[])Enum.GetValues(typeof(Keys)))
                .Where(k => k != Keys.None && !Enum.GetNames(typeof(KeyModifier)).Contains(k.ToString()))
                .OrderBy(k => k.ToString())
                .Distinct()
                .ToList();
            _keyCombo.DataSource = _keys;

            _functions = ((Keys[])Enum.GetValues(typeof(Keys)))
                .Where(k => k.ToString().StartsWith("Media"))
                .OrderByDescending(k => k.ToString())
                .ToList();
            _functionCombo.DataSource = _functions;
        }

        private void _registerButton_Click(object sender, EventArgs e)
        {
            var modifiers = _modifiersGroup.Controls.OfType<CheckBox>()
                .Where(chk => chk.Checked)
                .Select(check => (KeyModifier)check.Tag)
                .Aggregate((current, next) => current | next);
            HotkeyInfoResult = new HotkeyInfo(modifiers, (Keys)_keyCombo.SelectedValue, (Keys)_functionCombo.SelectedValue);
        }

        private void Control_Validating(object sender, CancelEventArgs e)
        {
            _registerButton.Enabled = 
                _modifiersGroup.Controls.OfType<CheckBox>().Any(chk => chk.Checked) &&
                _keyCombo.SelectedValue != null && 
                _functionCombo.SelectedValue != null;
        }

        private void _keyCombo_Validating(object sender, CancelEventArgs e)
        {
            if (_keyCombo.SelectedValue == null ||
                !Enum.IsDefined(typeof(Keys), _keyCombo.SelectedValue))
            {
                _keyCombo.BackColor = Color.Red;
                _incorrectKeyToolTip.Active = true;
                _incorrectKeyToolTip.Show( "Please select valid Key from the list.", _keyCombo);
                e.Cancel = true;
            }
            else
            {
                _incorrectKeyToolTip.Active = false;
                _keyCombo.BackColor = Color.White;
            }
            Control_Validating(sender, e);
        }

        private void Check_CheckedChanged(object sender, EventArgs e) => Control_Validating(sender, new CancelEventArgs());
    }
}
