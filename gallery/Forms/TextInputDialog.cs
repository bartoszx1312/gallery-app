namespace gallery.Forms
{
    public partial class TextInputDialog : Form
    {
        public string Value => textBox.Text;
        public string Password => txtPassword.Text;
        public bool IsPasswordProtected => chkPassword.Checked;

        public TextInputDialog(string title, string prompt)
        {
            InitializeComponent();
            Text = title;
            lblPrompt.Text = prompt;

            // Pokazujemy checkbox hasła tylko dla folderów
            bool isForFolder = title.Contains("folder", StringComparison.OrdinalIgnoreCase);
            chkPassword.Visible = isForFolder;

            // Domyślnie pole hasła jest ukryte
            lblPassword.Visible = false;
            txtPassword.Visible = false;

            // Ustawiamy początkowy rozmiar formularza
            this.ClientSize = new Size(this.ClientSize.Width, isForFolder ? 160 : 120);
            btnOK.Location = new Point(btnOK.Location.X, isForFolder ? 125 : 85);
            btnCancel.Location = new Point(btnCancel.Location.X, isForFolder ? 125 : 85);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("Proszę wprowadzić nazwę.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Dostosuj rozmiar formularza
            this.ClientSize = new Size(this.ClientSize.Width, chkPassword.Checked ? 160 : 120);
            // Dostosuj pozycję przycisków
            btnOK.Location = new Point(btnOK.Location.X, chkPassword.Checked ? 125 : 85);
            btnCancel.Location = new Point(btnCancel.Location.X, chkPassword.Checked ? 125 : 85);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
