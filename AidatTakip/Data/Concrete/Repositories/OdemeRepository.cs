using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.Data.Concrete.Repositories
{
    public class OdemeRepository : Repository<Odeme>, IOdemeRepository
    {
        public OdemeRepository(AidatTakipContext context) : base(context)
        {
        }
    }
}
