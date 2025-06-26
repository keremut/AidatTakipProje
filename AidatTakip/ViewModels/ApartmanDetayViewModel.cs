using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.ViewModels
{
    public class ApartmanDetayViewModel
    {
        public Apartman Apartman { get; set; } = null!;
        public Site Site { get; set; } = null!;
        public List<Daire> Daireler { get; set; } = new List<Daire>();
    }
}
