using NuGet.Protocol;

namespace Shop.Web.Models
{
    public class Favorites
    {
        public int OrderId { get; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }

        public Favorites(int orderId)
        {
            OrderId = orderId;
            TotalCount = 0;
            TotalPrice = 0m;
        }
    }
}
