namespace gallery.Forms
{
    partial class AddPhotoForm
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureBoxPreview;
        private Button btnSelectPhoto;
        private TextBox txtDescription;
        private Label lblDescription;
        private Button btnSave;
        private Button btnCancel;



        private void InitializeComponent()
        {
            pictureBoxPreview = new PictureBox();
            btnSelectPhoto = new Button();
            txtDescription = new TextBox();
            lblDescription = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxPreview.Location = new Point(12, 12);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(360, 240);
            pictureBoxPreview.TabIndex = 0;
            pictureBoxPreview.TabStop = false;
            // 
            // btnSelectPhoto
            // 
            btnSelectPhoto.Location = new Point(12, 258);
            btnSelectPhoto.Name = "btnSelectPhoto";
            btnSelectPhoto.Size = new Size(360, 29);
            btnSelectPhoto.TabIndex = 1;
            btnSelectPhoto.Text = "Select Photo";
            btnSelectPhoto.Click += btnSelectPhoto_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(12, 322);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(360, 76);
            txtDescription.TabIndex = 2;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(12, 299);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 409);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 29);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(197, 409);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(175, 29);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // AddPhotoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblDescription);
            Controls.Add(txtDescription);
            Controls.Add(btnSelectPhoto);
            Controls.Add(pictureBoxPreview);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddPhotoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Photo";
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
