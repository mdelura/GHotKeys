namespace GHotKeys
{
    partial class HotkeysWindow
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
            this._hotkeysGridView = new System.Windows.Forms.DataGridView();
            this.modifiersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.functionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._hotkeyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._registerButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._hotkeysGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._hotkeyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _hotkeysGridView
            // 
            this._hotkeysGridView.AllowUserToAddRows = false;
            this._hotkeysGridView.AllowUserToOrderColumns = true;
            this._hotkeysGridView.AutoGenerateColumns = false;
            this._hotkeysGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._hotkeysGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.modifiersDataGridViewTextBoxColumn,
            this.keyDataGridViewTextBoxColumn,
            this.functionDataGridViewTextBoxColumn});
            this._hotkeysGridView.DataSource = this._hotkeyBindingSource;
            this._hotkeysGridView.Location = new System.Drawing.Point(13, 13);
            this._hotkeysGridView.Name = "_hotkeysGridView";
            this._hotkeysGridView.ReadOnly = true;
            this._hotkeysGridView.Size = new System.Drawing.Size(426, 377);
            this._hotkeysGridView.TabIndex = 0;
            this._hotkeysGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._hotkeysGridView_UserDeletingRow);
            // 
            // modifiersDataGridViewTextBoxColumn
            // 
            this.modifiersDataGridViewTextBoxColumn.DataPropertyName = "Modifiers";
            this.modifiersDataGridViewTextBoxColumn.HeaderText = "Modifiers";
            this.modifiersDataGridViewTextBoxColumn.Name = "modifiersDataGridViewTextBoxColumn";
            this.modifiersDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // functionDataGridViewTextBoxColumn
            // 
            this.functionDataGridViewTextBoxColumn.DataPropertyName = "Function";
            this.functionDataGridViewTextBoxColumn.HeaderText = "Function";
            this.functionDataGridViewTextBoxColumn.Name = "functionDataGridViewTextBoxColumn";
            this.functionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _hotkeyBindingSource
            // 
            this._hotkeyBindingSource.DataSource = typeof(GHotKeys.Hotkey);
            // 
            // _registerButton
            // 
            this._registerButton.Location = new System.Drawing.Point(162, 409);
            this._registerButton.Name = "_registerButton";
            this._registerButton.Size = new System.Drawing.Size(126, 23);
            this._registerButton.TabIndex = 1;
            this._registerButton.Text = "Register new hotkey";
            this._registerButton.UseVisualStyleBackColor = true;
            this._registerButton.Click += new System.EventHandler(this._registerButton_Click);
            // 
            // HotkeysWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 444);
            this.Controls.Add(this._registerButton);
            this.Controls.Add(this._hotkeysGridView);
            this.Name = "HotkeysWindow";
            this.Text = "Hotkeys";
            ((System.ComponentModel.ISupportInitialize)(this._hotkeysGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._hotkeyBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _hotkeysGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn functionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource _hotkeyBindingSource;
        private System.Windows.Forms.Button _registerButton;
    }
}