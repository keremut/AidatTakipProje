using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.Data.Concrete.Repositories
{
    public class SiteRepository : Repository<Site>, ISiteRepository
    {
        public SiteRepository(AidatTakipContext context) : base(context)
        {
        }
    }
}
