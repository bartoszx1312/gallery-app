// Klasa reprezentująca pojedyncze zdjęcie w galerii
namespace gallery.Models
{
    public class PhotoItem
    {
        // Unikalny identyfikator zdjęcia
        public string Id { get; set; }
        
        // Ścieżka do pliku zdjęcia
        public string Path { get; set; }
        
        // Opis zdjęcia
        public string Description { get; set; }
        
        // Data dodania zdjęcia
        public DateTime AddedDate { get; set; }

        // Konstruktor tworzący nowe zdjęcie
        public PhotoItem()
        {
            Id = Guid.NewGuid().ToString();
            Path = "";
            Description = "";
            AddedDate = DateTime.Now;
        }
    }
}
