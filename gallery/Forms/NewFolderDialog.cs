using System;
using System.Windows.Forms;

namespace gallery.Forms
{
    public partial class NewFolderDialog : Form
    {
        public string FolderName => txtFolderName.Text;
        public string Password => txtPassword.Text;
        public bool IsPasswordProtected => chkPassword.Checked;

        public NewFolderDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFolderName.Text))
            {
                MessageBox.Show("Proszę wprowadzić nazwę folderu.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chkPassword.Checked && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Proszę wprowadzić hasło.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            lblPassword.Visible = chkPassword.Checked;
            txtPassword.Visible = chkPassword.Checked;
            if (!chkPassword.Checked)
            {
                txtPassword.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
