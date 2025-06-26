using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.ViewModels
{
    public class ApartmanViewModel
    {
        public List<Site> Sites { get; set; } = new List<Site>();
        public int DaireSayisi { get; set; } = 0;
        public List<Apartman> Apartmanlar { get; set; } = new List<Apartman>();
    }
}
