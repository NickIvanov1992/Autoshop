

using Shop.Domain;

namespace Shop.Data.EF
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
