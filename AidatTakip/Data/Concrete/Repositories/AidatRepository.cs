using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.Data.Concrete.Repositories
{
    public class AidatRepository : Repository<Aidat>, IAidatRepository
    {
        public AidatRepository(AidatTakipContext context) : base(context)
        {
        }
    }

}
