using Store.EF;
using Store.interfaces;
using Store.Models;

namespace Store.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly StoreDbContext storeDbContext;
        public CategoryRepository(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }

        public IEnumerable<Category> AllCategories => storeDbContext.Categories;
    }
}
