namespace gallery.Forms
{
    partial class TextInputDialog
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPrompt;
        private TextBox textBox;
        private Button btnOK;
        private Button btnCancel;
        private CheckBox chkPassword;
        private Label lblPassword;
        private TextBox txtPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblPrompt = new Label();
            this.textBox = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.chkPassword = new CheckBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            SuspendLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new Size(38, 15);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Location = new Point(12, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new Size(360, 23);
            this.textBox.TabIndex = 1;
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new Point(12, 56);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new Size(150, 19);
            this.chkPassword.TabIndex = 2;
            this.chkPassword.Text = "Zabezpiecz hasłem";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += new System.EventHandler(this.chkPassword_CheckedChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(12, 78);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(37, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Hasło:";
            this.lblPassword.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(12, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(360, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(216, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(297, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TextInputDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(384, 160);
            this.Controls.Clear();
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.chkPassword);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.lblPrompt);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "TextInputDialog";
            this.chkPassword.Visible = true;
            this.ResumeLayout(false);
            this.PerformLayout();
            // 
            // lblPrompt
            // 
            this.lblPrompt.AutoSize = true;
            this.lblPrompt.Location = new Point(12, 9);
            this.lblPrompt.Name = "lblPrompt";
            this.lblPrompt.Size = new Size(38, 15);
            this.lblPrompt.TabIndex = 0;
            this.lblPrompt.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Location = new Point(12, 27);
            this.textBox.Name = "textBox";
            this.textBox.Size = new Size(360, 23);
            this.textBox.TabIndex = 1;
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new Point(12, 56);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new Size(150, 19);
            this.chkPassword.TabIndex = 2;
            this.chkPassword.Text = "Zabezpiecz hasłem";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += chkPassword_CheckedChanged;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(12, 78);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(37, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Hasło:";
            this.lblPassword.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(12, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(360, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(216, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(297, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Anuluj";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += btnCancel_Click;
            // 
            // TextInputDialog
            // 
            this.AutoScaleDimensions = new SizeF(8F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(384, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.chkPassword);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.lblPrompt);
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "TextInputDialog";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
