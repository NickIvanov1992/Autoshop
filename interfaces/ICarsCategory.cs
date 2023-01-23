using Store.Models;

namespace Store.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; } //возвращает все категории
    }
}
