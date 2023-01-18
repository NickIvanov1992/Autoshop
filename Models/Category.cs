namespace Store.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }       //название категории
        public string Desc { get; set; }        // описание категорий
        public List<Car> cars { get; set; }     // список автомобилей в категории

    }
}
