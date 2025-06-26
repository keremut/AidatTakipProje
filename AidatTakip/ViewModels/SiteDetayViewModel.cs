using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.ViewModels
{
    public class SiteDetayViewModel
    {
        public Site site { get; set; }
        public List<Apartman> apartmanlar { get; set; } = new List<Apartman>();
    }
}
