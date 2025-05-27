using gallery.Services;

namespace gallery.Forms
{
    public partial class AddPhotoForm : Form
    {
        private readonly string _folderId;
        private readonly DataService _dataService;
        private string? _selectedPhotoPath;

        public AddPhotoForm(string folderId, DataService dataService)
        {
            InitializeComponent();
            _folderId = folderId;
            _dataService = dataService;
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Photo";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBoxPreview.Image != null)
                    {
                        pictureBoxPreview.Image.Dispose();
                        pictureBoxPreview.Image = null;
                    }

                    _selectedPhotoPath = openFileDialog.FileName;
                    pictureBoxPreview.Image = Image.FromFile(_selectedPhotoPath);
                    pictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                if (pictureBoxPreview.Image != null)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }
            }
            base.Dispose(disposing);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedPhotoPath))
            {
                MessageBox.Show("Please select a photo first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _dataService.AddPhotoToFolder(_folderId, _selectedPhotoPath, txtDescription.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
