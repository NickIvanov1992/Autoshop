namespace Shop.Domain
{
    public class StoreCartItem
    {
        public int Id { get; set; }
        public Car car { get;set; }
        public int Price { get; set; }
        public string StoreCartId { get; set; }
    }
}
