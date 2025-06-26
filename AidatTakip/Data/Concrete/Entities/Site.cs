using System.ComponentModel.DataAnnotations;

namespace AidatTakip.Data.Concrete.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Il { get; set; } = string.Empty;
        public string Ilce { get; set; } = string.Empty;
        public string? Aciklama { get; set; }

        public ICollection<Apartman> Apartmanlar { get; set; } = new List<Apartman>();
    }
}
