namespace GHotKeys
{
    partial class RegisterHotkeyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._modifiersGroup = new System.Windows.Forms.GroupBox();
            this._winCheck = new System.Windows.Forms.CheckBox();
            this._shiftCheck = new System.Windows.Forms.CheckBox();
            this._ctrlCheck = new System.Windows.Forms.CheckBox();
            this._altCheck = new System.Windows.Forms.CheckBox();
            this._plusLabel = new System.Windows.Forms.Label();
            this._keyCombo = new System.Windows.Forms.ComboBox();
            this._equalsLabel = new System.Windows.Forms.Label();
            this._functionCombo = new System.Windows.Forms.ComboBox();
            this._registerButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._incorrectKeyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this._modifiersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // _modifiersGroup
            // 
            this._modifiersGroup.Controls.Add(this._winCheck);
            this._modifiersGroup.Controls.Add(this._shiftCheck);
            this._modifiersGroup.Controls.Add(this._ctrlCheck);
            this._modifiersGroup.Controls.Add(this._altCheck);
            this._modifiersGroup.Location = new System.Drawing.Point(12, 12);
            this._modifiersGroup.Name = "_modifiersGroup";
            this._modifiersGroup.Size = new System.Drawing.Size(87, 113);
            this._modifiersGroup.TabIndex = 1;
            this._modifiersGroup.TabStop = false;
            this._modifiersGroup.Text = "Modifiers";
            this._modifiersGroup.Validating += new System.ComponentModel.CancelEventHandler(this.Control_Validating);
            // 
            // _winCheck
            // 
            this._winCheck.AutoSize = true;
            this._winCheck.Location = new System.Drawing.Point(7, 89);
            this._winCheck.Name = "_winCheck";
            this._winCheck.Size = new System.Drawing.Size(45, 17);
            this._winCheck.TabIndex = 3;
            this._winCheck.Text = "Win";
            this._winCheck.UseVisualStyleBackColor = true;
            this._winCheck.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // _shiftCheck
            // 
            this._shiftCheck.AutoSize = true;
            this._shiftCheck.Location = new System.Drawing.Point(7, 66);
            this._shiftCheck.Name = "_shiftCheck";
            this._shiftCheck.Size = new System.Drawing.Size(47, 17);
            this._shiftCheck.TabIndex = 2;
            this._shiftCheck.Text = "Shift";
            this._shiftCheck.UseVisualStyleBackColor = true;
            this._shiftCheck.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // _ctrlCheck
            // 
            this._ctrlCheck.AutoSize = true;
            this._ctrlCheck.Location = new System.Drawing.Point(7, 43);
            this._ctrlCheck.Name = "_ctrlCheck";
            this._ctrlCheck.Size = new System.Drawing.Size(41, 17);
            this._ctrlCheck.TabIndex = 1;
            this._ctrlCheck.Text = "Ctrl";
            this._ctrlCheck.UseVisualStyleBackColor = true;
            this._ctrlCheck.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // _altCheck
            // 
            this._altCheck.AutoSize = true;
            this._altCheck.Location = new System.Drawing.Point(7, 20);
            this._altCheck.Name = "_altCheck";
            this._altCheck.Size = new System.Drawing.Size(38, 17);
            this._altCheck.TabIndex = 0;
            this._altCheck.Text = "Alt";
            this._altCheck.UseVisualStyleBackColor = true;
            this._altCheck.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // _plusLabel
            // 
            this._plusLabel.AutoSize = true;
            this._plusLabel.Location = new System.Drawing.Point(106, 62);
            this._plusLabel.Name = "_plusLabel";
            this._plusLabel.Size = new System.Drawing.Size(13, 13);
            this._plusLabel.TabIndex = 2;
            this._plusLabel.Text = "+";
            // 
            // _keyCombo
            // 
            this._keyCombo.FormattingEnabled = true;
            this._keyCombo.Location = new System.Drawing.Point(126, 58);
            this._keyCombo.Name = "_keyCombo";
            this._keyCombo.Size = new System.Drawing.Size(121, 21);
            this._keyCombo.TabIndex = 4;
            this._keyCombo.Validating += new System.ComponentModel.CancelEventHandler(this._keyCombo_Validating);
            // 
            // _equalsLabel
            // 
            this._equalsLabel.AutoSize = true;
            this._equalsLabel.Location = new System.Drawing.Point(253, 62);
            this._equalsLabel.Name = "_equalsLabel";
            this._equalsLabel.Size = new System.Drawing.Size(13, 13);
            this._equalsLabel.TabIndex = 4;
            this._equalsLabel.Text = "=";
            // 
            // _functionCombo
            // 
            this._functionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._functionCombo.FormattingEnabled = true;
            this._functionCombo.Location = new System.Drawing.Point(272, 58);
            this._functionCombo.Name = "_functionCombo";
            this._functionCombo.Size = new System.Drawing.Size(121, 21);
            this._functionCombo.TabIndex = 5;
            this._functionCombo.Validating += new System.ComponentModel.CancelEventHandler(this.Control_Validating);
            // 
            // _registerButton
            // 
            this._registerButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._registerButton.Enabled = false;
            this._registerButton.Location = new System.Drawing.Point(220, 133);
            this._registerButton.Name = "_registerButton";
            this._registerButton.Size = new System.Drawing.Size(75, 23);
            this._registerButton.TabIndex = 7;
            this._registerButton.Text = "Register";
            this._registerButton.UseVisualStyleBackColor = true;
            this._registerButton.Click += new System.EventHandler(this._registerButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(301, 133);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 8;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _incorrectKeyToolTip
            // 
            this._incorrectKeyToolTip.Active = false;
            // 
            // RegisterHotkeyForm
            // 
            this.AcceptButton = this._registerButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.ClientSize = new System.Drawing.Size(402, 169);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._registerButton);
            this.Controls.Add(this._functionCombo);
            this.Controls.Add(this._equalsLabel);
            this.Controls.Add(this._keyCombo);
            this.Controls.Add(this._plusLabel);
            this.Controls.Add(this._modifiersGroup);
            this.Name = "RegisterHotkeyForm";
            this.Text = "Register New Hotkey";
            this._modifiersGroup.ResumeLayout(false);
            this._modifiersGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox _modifiersGroup;
        private System.Windows.Forms.CheckBox _winCheck;
        private System.Windows.Forms.CheckBox _shiftCheck;
        private System.Windows.Forms.CheckBox _ctrlCheck;
        private System.Windows.Forms.CheckBox _altCheck;
        private System.Windows.Forms.Label _plusLabel;
        private System.Windows.Forms.ComboBox _keyCombo;
        private System.Windows.Forms.Label _equalsLabel;
        private System.Windows.Forms.ComboBox _functionCombo;
        private System.Windows.Forms.Button _registerButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ToolTip _incorrectKeyToolTip;
    }
}