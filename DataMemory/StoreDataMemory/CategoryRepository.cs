using DataMemory.EF;
using domain.store.interfaces;
using domain.store;

namespace DataMemory.StoreDataMemory
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
