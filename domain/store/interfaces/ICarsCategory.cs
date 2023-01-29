using domain.store;

namespace domain.store.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; } //возвращает все категории
    }
}
