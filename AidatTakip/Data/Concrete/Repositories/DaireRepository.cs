using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.Data.Concrete.Repositories
{
    public class DaireRepository : Repository<Daire>, IDaireRepository
    {
        public DaireRepository(AidatTakipContext context) : base(context)
        {
        }
    }
}
