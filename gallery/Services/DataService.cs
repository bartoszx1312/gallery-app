using System.Text.Json;
using gallery.Models;
using System.Windows.Forms;

// Klasa zarządzająca zapisem i odczytem danych
namespace gallery.Services
{
    public class DataService
    {
        // Ścieżka do pliku JSON z danymi
        private readonly string dataPath;
        
        // Ścieżka do folderu ze zdjęciami
        private readonly string imagesPath;
        
        // Lista folderów
        private List<FolderItem> folderList;

        // Właściwość zwracająca ścieżkę do folderu ze zdjęciami
        public string ImagesPath
        {
            get { return imagesPath; }
        }

        // Konstruktor - tworzy folder aplikacji i wczytuje dane
        public DataService()
        {
            // Inicjalizacja ścieżek do plików - używamy katalogu projektu jako bazowego
            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.ExecutablePath)))) ?? AppDomain.CurrentDomain.BaseDirectory;
            
            // Ustawiamy ścieżki
            dataPath = Path.Combine(projectPath, "data.json");
            imagesPath = Path.Combine(projectPath, "images");
            
            // Tworzymy folder na zdjęcia
            Directory.CreateDirectory(imagesPath);
            
            // Tworzymy pustą listę folderów
            folderList = new List<FolderItem>();

            // Wczytujemy dane
            LoadData();
            
            // Wyświetlamy informację o lokalizacji danych
            Console.WriteLine($"Folder aplikacji: {projectPath}");
            Console.WriteLine($"Folder zdjęć: {imagesPath}");
            Console.WriteLine($"Plik danych: {dataPath}");
        }

        // Zwraca listę wszystkich folderów
        public List<FolderItem> GetFolders()
        {
            return folderList;
        }

        // Dodaje nowy folder i zwraca go
        public FolderItem AddFolder(FolderItem folder)
        {
            // Dodajemy folder do listy
            folderList.Add(folder);
            
            // Zapisujemy zmiany
            SaveData();

            return folder;
        }

        // Dodaje zdjęcie do wybranego folderu
        public void AddPhotoToFolder(string folderId, string sourcePhotoPath, string description)
        {
            if (string.IsNullOrEmpty(folderId) || string.IsNullOrEmpty(sourcePhotoPath))
                return;

            try
            {
                var folder = GetFolder(folderId);
                if (folder == null) return;

                // Tworzymy folder na dysku dla zdjęć
                string folderPath = Path.Combine(imagesPath, folder.Id);
                Directory.CreateDirectory(folderPath);

                // Tworzymy nowe zdjęcie
                PhotoItem newPhoto = new PhotoItem
                {
                    Description = description ?? ""
                };

                // Kopiujemy plik zdjęcia
                string extension = Path.GetExtension(sourcePhotoPath);
                string newFileName = newPhoto.Id + extension;
                string newPath = Path.Combine(folderPath, newFileName);

                // Kopiujemy plik
                File.Copy(sourcePhotoPath, newPath, true);

                // Ustawiamy właściwości zdjęcia - zapisujemy ścieżkę względem katalogu aplikacji
                newPhoto.Path = Path.Combine("images", folder.Id, newFileName);

                // Dodajemy zdjęcie do folderu
                folder.Photos.Add(newPhoto);

                // Zapisujemy zmiany
                SaveData();

                MessageBox.Show($"Zdjęcie zostało dodane do folderu.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Wyświetlamy informacje o ścieżkach
                Console.WriteLine($"Skopiowano zdjęcie z: {sourcePhotoPath}");
                Console.WriteLine($"Do: {newPath}");
                Console.WriteLine($"Zapisana ścieżka: {newPhoto.Path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu zdjęcia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FolderItem? GetFolder(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return folderList.FirstOrDefault(f => f.Id == id);
        }

        // Usuwa folder i wszystkie jego zdjęcia
        public void RemoveFolder(string folderId)
        {
            // Szukamy folderu do usunięcia
            FolderItem folderToRemove = null;
            foreach (var folder in folderList)
            {
                if (folder.Id == folderId)
                {
                    folderToRemove = folder;
                    break;
                }
            }

            // Jeśli znaleziono folder
            if (folderToRemove != null)
            {
                // Usuwamy folder ze zdjęciami z dysku
                string folderPath = Path.Combine(imagesPath, folderToRemove.Id);
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }

                // Usuwamy folder z listy
                folderList.Remove(folderToRemove);
                
                // Zapisujemy zmiany
                SaveData();
            }
        }

        // Usuwa zdjęcie z folderu
        public void RemovePhoto(string folderId, string photoId)
        {
            if (string.IsNullOrEmpty(folderId) || string.IsNullOrEmpty(photoId))
                return;

            try
            {
                var folder = GetFolder(folderId);
                if (folder == null) return;

                var photo = GetPhoto(folderId, photoId);
                if (photo == null) return;

                // Usuwamy plik z dysku
                if (File.Exists(photo.Path))
                {
                    File.Delete(photo.Path);
                }

                // Usuwamy zdjęcie z listy
                folder.Photos.Remove(photo);

                // Zapisujemy zmiany
                SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy usuwaniu zdjęcia: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PhotoItem? GetPhoto(string folderId, string photoId)
        {
            var folder = GetFolder(folderId);
            if (folder == null) return null;

            return folder.Photos.FirstOrDefault(p => p.Id == photoId);
        }

        // Wczytuje dane z pliku JSON
        private void LoadData()
        {
            try
            {
                // Sprawdzamy czy plik istnieje
                if (File.Exists(dataPath))
                {
                    // Wczytujemy zawartosc pliku
                    string jsonContent = File.ReadAllText(dataPath);
                    Console.WriteLine($"Wczytana zawartość pliku: {jsonContent}");
                    
                    // Konwertujemy JSON na liste folderow
                    folderList = JsonSerializer.Deserialize<List<FolderItem>>(jsonContent);
                    
                    // Jesli lista jest pusta, tworzymy nowa
                    if (folderList == null)
                    {
                        folderList = new List<FolderItem>();
                        Console.WriteLine("Lista folderów była null, utworzono nową listę");
                    }
                    else
                    {
                        Console.WriteLine($"Wczytano {folderList.Count} folderów");
                    }
                }
                else
                {
                    // Jeśli plik nie istnieje, tworzymy nową listę
                    folderList = new List<FolderItem>();
                    Console.WriteLine("Plik danych nie istnieje, utworzono nową listę");
                }
            }
            catch (Exception ex)
            {
                // W razie błędu tworzymy nową listę
                folderList = new List<FolderItem>();
                Console.WriteLine($"Błąd przy wczytywaniu danych: {ex.Message}");
                MessageBox.Show($"Błąd przy wczytywaniu danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Zapisuje dane do pliku JSON
        private void SaveData()
        {
            try
            {
                // Ustawienia serializacji JSON
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // Formatowanie JSON dla czytelnosci
                };

                // Konwertujemy liste folderow na JSON
                string jsonContent = JsonSerializer.Serialize(folderList, options);
                Console.WriteLine($"Zapisywana zawartość: {jsonContent}");
                
                // Zapisujemy do pliku
                File.WriteAllText(dataPath, jsonContent);
                Console.WriteLine($"Dane zapisane do pliku: {dataPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy zapisywaniu danych: {ex.Message}");
                MessageBox.Show($"Błąd przy zapisywaniu danych: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
