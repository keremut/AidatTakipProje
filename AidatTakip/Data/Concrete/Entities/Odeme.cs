namespace AidatTakip.Data.Concrete.Entities
{
    public class Odeme
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }

        public int AidatId { get; set; }
        public Aidat Aidat { get; set; } = new Aidat();
    }
}
