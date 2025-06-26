namespace AidatTakip.Data.Concrete.Entities
{
    public class Aidat
    {
        public int Id { get; set; }
        public int Ay { get; set; } // 1-12
        public int Yil { get; set; }
        public decimal Tutar { get; set; }

        public int DaireId { get; set; }
        public Daire Daire { get; set; } = null!;

        public ICollection<Odeme> Odemeler { get; set; } = new List<Odeme>();
        public bool OdendiMi => Odemeler.Sum(o => o.Tutar) >= Tutar;

    }
}
