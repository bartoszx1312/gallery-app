namespace gallery.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewFolders;
        private ListView listViewPhotos;
        private Button btnAddFolder;
        private Button btnAddPhoto;
        private ContextMenuStrip folderContextMenu;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ContextMenuStrip photoContextMenu;
        private ToolStripMenuItem deletePhotoToolStripMenuItem;
        private ImageList imageList;
        private ImageList imageList1;
        private PictureBox pictureBox1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Panel panel1;
        private Label lblPhotoDescription;

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
            components = new System.ComponentModel.Container();
            listViewFolders = new ListView();
            folderContextMenu = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            imageList = new ImageList(components);
            listViewPhotos = new ListView();
            photoContextMenu = new ContextMenuStrip(components);
            deletePhotoToolStripMenuItem = new ToolStripMenuItem();
            imageList1 = new ImageList(components);
            btnAddFolder = new Button();
            btnAddPhoto = new Button();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            folderContextMenu.SuspendLayout();
            photoContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // listViewFolders
            // 
            listViewFolders.BackColor = Color.White;
            listViewFolders.BorderStyle = BorderStyle.None;
            listViewFolders.ContextMenuStrip = folderContextMenu;
            listViewFolders.Dock = DockStyle.Fill;
            listViewFolders.LargeImageList = imageList;
            listViewFolders.Location = new Point(0, 0);
            listViewFolders.Margin = new Padding(3, 2, 3, 2);
            listViewFolders.MultiSelect = false;
            listViewFolders.Name = "listViewFolders";
            listViewFolders.Size = new Size(1225, 200);
            listViewFolders.TabIndex = 0;
            listViewFolders.TileSize = new Size(100, 100);
            listViewFolders.UseCompatibleStateImageBehavior = false;
            // 
            // folderContextMenu
            // 
            folderContextMenu.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem });
            folderContextMenu.Name = "folderContextMenu";
            folderContextMenu.Size = new Size(136, 26);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(135, 22);
            deleteToolStripMenuItem.Text = "Usuń folder";
            // 
            // imageList
            // 
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(48, 48);
            imageList.TransparentColor = Color.Transparent;
            // 
            // listViewPhotos
            // 
            listViewPhotos.BackColor = Color.White;
            listViewPhotos.BorderStyle = BorderStyle.None;
            listViewPhotos.ContextMenuStrip = photoContextMenu;
            listViewPhotos.Dock = DockStyle.Fill;
            listViewPhotos.LargeImageList = imageList1;
            listViewPhotos.Location = new Point(0, 0);
            listViewPhotos.Margin = new Padding(3, 2, 3, 2);
            listViewPhotos.MultiSelect = false;
            listViewPhotos.Name = "listViewPhotos";
            listViewPhotos.Size = new Size(1225, 267);
            listViewPhotos.TabIndex = 0;
            listViewPhotos.UseCompatibleStateImageBehavior = false;
            // 
            // photoContextMenu
            // 
            photoContextMenu.Items.AddRange(new ToolStripItem[] { deletePhotoToolStripMenuItem });
            photoContextMenu.Name = "photoContextMenu";
            photoContextMenu.Size = new Size(141, 26);
            // 
            // deletePhotoToolStripMenuItem
            // 
            deletePhotoToolStripMenuItem.Name = "deletePhotoToolStripMenuItem";
            deletePhotoToolStripMenuItem.Size = new Size(140, 22);
            deletePhotoToolStripMenuItem.Text = "Usuń zdjęcie";
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(200, 200);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // btnAddFolder
            // 
            btnAddFolder.BackColor = Color.White;
            btnAddFolder.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnAddFolder.FlatStyle = FlatStyle.Flat;
            btnAddFolder.Location = new Point(12, 8);
            btnAddFolder.Margin = new Padding(3, 2, 3, 2);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(120, 30);
            btnAddFolder.TabIndex = 0;
            btnAddFolder.Text = "Dodaj folder";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Visible = true;
            // 
            // btnAddPhoto
            // 
            btnAddPhoto.BackColor = Color.White;
            btnAddPhoto.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnAddPhoto.FlatStyle = FlatStyle.Flat;
            btnAddPhoto.Location = new Point(140, 8);
            btnAddPhoto.Margin = new Padding(3, 2, 3, 2);
            btnAddPhoto.Name = "btnAddPhoto";
            btnAddPhoto.Size = new Size(120, 30);
            btnAddPhoto.TabIndex = 1;
            btnAddPhoto.Text = "Dodaj zdjęcie";
            btnAddPhoto.UseVisualStyleBackColor = true;
            btnAddPhoto.Visible = true;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(240, 240, 240);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 45);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(listViewFolders);
            splitContainer1.Panel1.Padding = new Padding(9, 8, 9, 8);
            splitContainer1.Panel1MinSize = 200;
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Panel2.Padding = new Padding(9, 8, 9, 8);
            splitContainer1.Panel2MinSize = 700;
            splitContainer1.Size = new Size(1225, 630);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(listViewPhotos);
            splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(pictureBox1);
            splitContainer2.Panel2MinSize = 200;
            splitContainer2.Size = new Size(1225, 471);
            splitContainer2.SplitterDistance = 267;
            splitContainer2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(9, 8, 9, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1225, 170);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            
            // lblPhotoDescription
            //
            lblPhotoDescription = new Label();
            lblPhotoDescription.BackColor = Color.White;
            lblPhotoDescription.Dock = DockStyle.Bottom;
            lblPhotoDescription.Location = new Point(0, 170);
            lblPhotoDescription.Size = new Size(1225, 30);
            lblPhotoDescription.TextAlign = ContentAlignment.MiddleCenter;
            lblPhotoDescription.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblPhotoDescription.Text = "";
            splitContainer2.Panel2.Controls.Add(lblPhotoDescription);
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1225, 675);
            Controls.Add(splitContainer1);
            Controls.Add(btnAddFolder);
            Controls.Add(btnAddPhoto);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(800, 600);
            Name = "MainForm";
            Padding = new Padding(0, 45, 0, 0);
            Text = "Gallery App";
            folderContextMenu.ResumeLayout(false);
            photoContextMenu.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }
    }
}
