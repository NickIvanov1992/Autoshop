namespace Shop.Domain
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; } //возвращает все категории
    }
}
