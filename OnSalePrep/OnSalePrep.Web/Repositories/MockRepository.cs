using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Repositories
{
    public class MockRepository : IRepository
    {
        public void AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public bool CountryExists(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetCountries()
        {
            var countries = new List<Country>();
            countries.Add(new Country { Id = 1, Name = "País 1" });
            countries.Add(new Country { Id = 1, Name = "País 2" });
            countries.Add(new Country { Id = 1, Name = "País 3" });
            countries.Add(new Country { Id = 1, Name = "País 4" });
            countries.Add(new Country { Id = 1, Name = "País 5" });
            countries.Add(new Country { Id = 1, Name = "País 6" });
            countries.Add(new Country { Id = 1, Name = "País 7" });
            countries.Add(new Country { Id = 1, Name = "País 8" });
            return countries;
        }

        public Country GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
