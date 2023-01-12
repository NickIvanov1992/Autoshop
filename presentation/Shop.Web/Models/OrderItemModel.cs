namespace Shop.Web.Models
{
    public class OrderItemModel    /// data transfer object class    содержит только свойства
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Count { get; set; }
        public decimal Price {get; set;}
    }
}
