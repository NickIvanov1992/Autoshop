namespace Store.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public uint Price { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }

    }
}
