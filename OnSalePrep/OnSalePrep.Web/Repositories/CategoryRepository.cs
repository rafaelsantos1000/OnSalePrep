using OnSalePrep.Web.Data;
using OnSalePrep.Web.Data.Entities;

namespace OnSalePrep.Web.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
