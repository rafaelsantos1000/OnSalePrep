using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Repositories
{
    public interface IRepository
    {
        void AddCountry(Country country);

        bool CountryExists(int id);

        IEnumerable<Country> GetCountries();

        Country GetCountry(int id);

        void RemoveCountry(Country country);

        Task<bool> SaveAllAsync();

        void UpdateCountry(Country country);
    }
}