// Klasa reprezentująca folder ze zdjęciami
namespace gallery.Models
{
    public class FolderItem
    {
        // Unikalny identyfikator folderu
        public string Id { get; set; }
        
        // Nazwa folderu
        public string Name { get; set; }
        
        // Hasło do folderu
        public string Password { get; set; }
        
        // Czy folder jest zabezpieczony hasłem
        public bool IsPasswordProtected => !string.IsNullOrEmpty(Password);
        
        // Lista zdjęć w folderze
        public List<PhotoItem> Photos { get; set; }
        
        // Data utworzenia folderu
        public DateTime CreatedDate { get; set; }

        // Konstruktor tworzący nowy folder
        public FolderItem()
        {
            Id = Guid.NewGuid().ToString();
            Name = "";
            Password = "";
            Photos = new List<PhotoItem>();
            CreatedDate = DateTime.Now;
        }

        // Konstruktor tworzący nowy folder o podanej nazwie
        public FolderItem(string name) : this()
        {
            Name = name;
        }
    }
}
