namespace gallery.Forms
{
    partial class NewFolderDialog
    {
        private System.ComponentModel.IContainer components = null;

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
            lblFolderName = new Label();
            txtFolderName = new TextBox();
            chkPassword = new CheckBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFolderName
            // 
            lblFolderName.AutoSize = true;
            lblFolderName.Location = new Point(12, 9);
            lblFolderName.Name = "lblFolderName";
            lblFolderName.Size = new Size(86, 15);
            lblFolderName.TabIndex = 0;
            lblFolderName.Text = "Nazwa folderu:";
            // 
            // txtFolderName
            // 
            txtFolderName.Location = new Point(12, 27);
            txtFolderName.Name = "txtFolderName";
            txtFolderName.Size = new Size(360, 23);
            txtFolderName.TabIndex = 1;
            // 
            // chkPassword
            // 
            chkPassword.AutoSize = true;
            chkPassword.Location = new Point(12, 56);
            chkPassword.Name = "chkPassword";
            chkPassword.Size = new Size(150, 19);
            chkPassword.TabIndex = 2;
            chkPassword.Text = "Zabezpiecz hasłem";
            chkPassword.UseVisualStyleBackColor = true;
            chkPassword.CheckedChanged += chkPassword_CheckedChanged;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(12, 78);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(40, 15);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Hasło:";
            lblPassword.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 96);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(360, 23);
            txtPassword.TabIndex = 4;
            txtPassword.Visible = false;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(216, 125);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(297, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Anuluj";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // NewFolderDialog
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(384, 160);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(chkPassword);
            Controls.Add(txtFolderName);
            Controls.Add(lblFolderName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "NewFolderDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nowy folder";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblFolderName;
        private TextBox txtFolderName;
        private CheckBox chkPassword;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnOK;
        private Button btnCancel;
    }
}
