namespace AidatTakip.Data.Concrete.Entities
{
    public class Daire
    {
        public int Id { get; set; }
        public string No { get; set; } = string.Empty;
        public string DaireSorumlu { get; set; } = string.Empty;
        public string SorumluTel { get; set; } = string.Empty;
        public string SorumluImage { get; set; } = string.Empty;

        public int ApartmanId { get; set; }
        public Apartman Apartman { get; set; } = null!;

        public ICollection<Aidat> Aidatlar { get; set; } = new List<Aidat>();

    }
}
