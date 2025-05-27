using gallery.Models;
using gallery.Services;

namespace gallery.Forms
{
    public partial class MainForm : Form
    {
        // Serwis do zarządzania danymi
        private readonly DataService dataService;

        // Aktualnie wybrany folder
        private string? selectedFolderId;

        // Aktualnie wybrane zdjęcie
        private PhotoItem? selectedPhoto;

        public MainForm()
        {
            InitializeComponent();
            
            // Inicjalizacja serwisu danych
            dataService = new DataService();
            
            // Konfiguracja listy miniatur
            imageList1.ImageSize = new Size(200, 200);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            listViewPhotos.LargeImageList = imageList1;
            listViewPhotos.View = View.LargeIcon;
            
            // Konfiguracja listy folderów
            listViewFolders.View = View.LargeIcon;
            listViewFolders.LargeImageList = imageList;
            listViewFolders.TileSize = new Size(80, 80);

            // Ładowanie ikony folderu
            try
            {
                imageList.Images.Add(Image.FromFile("Vega-Album\\Folder.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nie można załadować ikony folderu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            // Konfiguracja wyglądu i zdarzeń
            ConfigureAppearance();
            ConfigureEvents();
            
            // Wczytanie folderów
            LoadFolders();
        }

        // Wczytuje listę folderów do listView
        private void LoadFolders()
        {
            // Czyścimy listę
            listViewFolders.Items.Clear();

            // Pobieramy foldery z serwisu
            List<FolderItem> folders = dataService.GetFolders();

            // Dodajemy każdy folder do listView
            foreach (FolderItem folder in folders)
            {
                ListViewItem item = new ListViewItem(folder.Name);
                item.Tag = folder;
                item.ImageIndex = 0; // Ikona folderu
                item.Text = folder.Name; // Nazwa pod ikoną
                listViewFolders.Items.Add(item);
            }
        }

        // Obsługa przycisku dodawania nowego folderu
        private void btnAddFolder_Click(object? sender, EventArgs e)
        {
            var dialog = new NewFolderDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var folder = new FolderItem
                {
                    Name = dialog.FolderName,
                    Password = dialog.IsPasswordProtected ? dialog.Password : null
                };

                var addedFolder = dataService.AddFolder(folder);
                LoadFolders();
                LoadPhotos(addedFolder.Id);
            }
        }

        // Obsługa przycisku dodawania nowego zdjęcia
        private void btnAddPhoto_Click(object? sender, EventArgs e)
        {
            // Sprawdzamy czy wybrano folder
            if (listViewFolders.SelectedItems.Count == 0)
            {
                MessageBox.Show("Najpierw wybierz folder!", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sprawdzamy czy wybrany element to folder
            if (listViewFolders.SelectedItems[0].Tag is not FolderItem folder)
            {
                MessageBox.Show("Błąd: Nieprawidłowy typ elementu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Otwieramy okno dodawania zdjęcia
            using (AddPhotoForm form = new AddPhotoForm(folder.Id, dataService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Odświeżamy listę zdjęć
                    LoadPhotos(folder.Id);
                }
            }
        }

        // Obsługa zmiany wybranego folderu
        private void listViewFolders_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listViewFolders.SelectedItems.Count > 0)
            {
                var selectedFolder = (FolderItem)listViewFolders.SelectedItems[0].Tag;
                
                // Sprawdzamy, czy folder jest zabezpieczony hasłem
                if (selectedFolder.IsPasswordProtected)
                {
                    var passwordDialog = new TextInputDialog("Hasło", "Wprowadź hasło do folderu:");
                    if (passwordDialog.ShowDialog() == DialogResult.OK)
                    {
                        if ((string)passwordDialog.Value == (string)selectedFolder.Password)
                        {
                            selectedFolderId = selectedFolder.Id;
                            LoadPhotos(selectedFolderId);
                        }
                        else
                        {
                            MessageBox.Show("Nieprawidłowe hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listViewFolders.SelectedItems.Clear();
                        }
                    }
                    else
                    {
                        listViewFolders.SelectedItems.Clear();
                    }
                }
                else
                {
                    selectedFolderId = selectedFolder.Id;
                    LoadPhotos(selectedFolderId);
                }
            }
            else
            {
                selectedFolderId = null;
                LoadPhotos(null);
            }
        }

        // Wczytuje zdjęcia z wybranego folderu
        private void LoadPhotos(string? folderId)
        {
            try
            {
                // Czyścimy listę zdjęć i miniatury
                imageList1.Images.Clear();
                listViewPhotos.Items.Clear();

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                if (string.IsNullOrEmpty(folderId)) return;

                var folder = dataService.GetFolder(folderId);
                if (folder == null) return;

                // Ustawienie właściwości ListView
                listViewPhotos.View = View.LargeIcon;
                imageList1.ImageSize = new Size(200, 200);
                listViewPhotos.LargeImageList = imageList1;

                // Dodajemy każde zdjęcie do listView
                foreach (PhotoItem photo in folder.Photos)
                {
                    string fullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(dataService.ImagesPath), photo.Path));
                    Console.WriteLine($"Próba wczytania zdjęcia: {fullPath}");

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            // Tworzymy miniaturę
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            using (Image img = Image.FromStream(stream))
                            {
                                Image thumb = img.GetThumbnailImage(200, 200, null, IntPtr.Zero);
                                imageList1.Images.Add(photo.Id, thumb);

                                // Dodajemy element do listView
                                ListViewItem item = new ListViewItem();
                                item.ImageKey = photo.Id;
                                item.Tag = photo;
                                item.Text = "";
                                item.ToolTipText = photo.Description;
                                listViewPhotos.Items.Add(item);

                                Console.WriteLine($"Zdjęcie wczytane pomyślnie: {fullPath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Błąd przy ładowaniu zdjęcia {Path.GetFileName(fullPath)}: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine($"Błąd przy ładowaniu zdjęcia: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Nie można znaleźć pliku zdjęcia: {fullPath}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"Nie znaleziono pliku: {fullPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy ładowaniu zdjęć: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obsługa usuwania folderu
        private void deleteToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (listViewFolders.SelectedItems.Count > 0)
            {
                var folder = (FolderItem)listViewFolders.SelectedItems[0].Tag;

                // Sprawdzamy, czy folder jest zabezpieczony hasłem
                if (folder.IsPasswordProtected)
                {
                    var passwordDialog = new TextInputDialog("Hasło", "Wprowadź hasło do folderu:");
                    if (passwordDialog.ShowDialog() != DialogResult.OK || passwordDialog.Value != folder.Password)
                    {
                        MessageBox.Show("Nieprawidłowe hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (MessageBox.Show("Czy na pewno chcesz usunąć ten folder?", "Potwierdzenie", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataService.RemoveFolder(folder.Id);
                    selectedFolderId = null;
                    LoadFolders();
                    LoadPhotos(null);
                }
            }
        }

        // Obsługa usuwania zdjęcia
        private void deletePhotoToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (listViewPhotos.SelectedItems.Count > 0 && selectedFolderId != null)
            {
                var photo = (PhotoItem)listViewPhotos.SelectedItems[0].Tag;
                if (MessageBox.Show("Czy na pewno chcesz usunąć to zdjęcie?", "Potwierdzenie", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dataService.RemovePhoto(selectedFolderId, photo.Id);
                    LoadPhotos(selectedFolderId);
                }
            }
        }

        // Obsługa wyboru zdjęcia
        private void listViewPhotos_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                // Jeśli wybrano zdjęcie
                if (listViewPhotos.SelectedItems.Count > 0 && listViewPhotos.SelectedItems[0].Tag is PhotoItem photo)
                {
                    // Pobieramy wybrane zdjęcie
                    selectedPhoto = photo;

                    // Aktualizujemy opis zdjęcia
                    lblPhotoDescription.Text = !string.IsNullOrEmpty(photo.Description) ? photo.Description : "Brak opisu";

                    // Aktualizujemy podgląd zdjęcia
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    string fullPath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(dataService.ImagesPath), selectedPhoto.Path));
                    Console.WriteLine($"Próba wczytania podglądu: {fullPath}");

                    if (File.Exists(fullPath))
                    {
                        try
                        {
                            // Wczytujemy zdjęcie do podglądu
                            using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                            {
                                pictureBox1.Image = Image.FromStream(stream);
                                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                                Console.WriteLine($"Podgląd wczytany pomyślnie: {fullPath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Błąd przy ładowaniu zdjęcia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            pictureBox1.Image = null;
                            Console.WriteLine($"Błąd przy ładowaniu podglądu: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Nie można znaleźć pliku zdjęcia: {fullPath}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine($"Nie znaleziono pliku podglądu: {fullPath}");
                    }
                }
                else
                {
                    // Jeśli nie wybrano zdjęcia, czyścimy podgląd i opis
                    selectedPhoto = null;
                    lblPhotoDescription.Text = "";
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy zmianie zdjęcia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Konfiguracja wyglądu aplikacji
        private void ConfigureAppearance()
        {
            // Ustawienie koloru tła
            BackColor = Color.FromArgb(240, 240, 240);

            // Przyciski
            btnAddFolder.BackColor = Color.White;
            btnAddPhoto.BackColor = Color.White;

            // Listy
            listViewFolders.BackColor = Color.White;
            listViewPhotos.BackColor = Color.White;

            // Panele
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel2.BackColor = Color.White;
            panel1.BackColor = Color.White;

            // Podgląd zdjęcia
            pictureBox1.BackColor = Color.White;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        // Konfiguracja zdarzeń
        private void ConfigureEvents()
        {
            // Przyciski
            btnAddFolder.Click += btnAddFolder_Click;
            btnAddPhoto.Click += btnAddPhoto_Click;

            // Listy
            listViewFolders.SelectedIndexChanged += listViewFolders_SelectedIndexChanged;
            listViewPhotos.SelectedIndexChanged += listViewPhotos_SelectedIndexChanged;

            // Menu kontekstowe
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            deletePhotoToolStripMenuItem.Click += deletePhotoToolStripMenuItem_Click;
        }
    }
}
