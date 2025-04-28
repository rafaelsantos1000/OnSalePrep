using OnSalePrep.Web.Data;
using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {
        }
    }
}
