namespace Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }       //название категории
        public List<Car> cars { get; set; }     // список автомобилей в категории

    }
}
