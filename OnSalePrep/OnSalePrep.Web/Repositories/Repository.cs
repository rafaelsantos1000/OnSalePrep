using OnSalePrep.Web.Data;
using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Name);
        }

        public Country GetCountry(int id)
        {
            return _context.Countries.Find(id)!;
        }

        public void AddCountry(Country country)
        {
            _context.Countries.Add(country);
        }

        public void UpdateCountry(Country country)
        {
            _context.Update(country);
        }

        public void RemoveCountry(Country country)
        {
            _context.Countries.Remove(country);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool CountryExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }
    }
}
