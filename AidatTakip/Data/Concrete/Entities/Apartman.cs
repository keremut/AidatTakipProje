namespace AidatTakip.Data.Concrete.Entities
{
    public class Apartman
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;

        public int SiteId { get; set; } 
        public Site Site { get; set; }

        public ICollection<Daire> Daireler { get; set; } = new List<Daire>();
    }
}
