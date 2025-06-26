using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;

namespace AidatTakip.Data.Concrete.Repositories
{
    public class ApartmanRepository : Repository<Apartman>, IApartmanRepository
    {
        public ApartmanRepository(AidatTakipContext context) : base(context)
        {
        }
    }
}
