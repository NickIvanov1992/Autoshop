using Microsoft.EntityFrameworkCore;
using Store.EF;

namespace Store.Models
{
    public class StoreCart
    {
        private readonly StoreDbContext storeDbContext;
        public StoreCart(StoreDbContext storeDbContext)
        {
            this.storeDbContext = storeDbContext;
        }
        public string StoreCartId { get; set; }
        public List<StoreCartItem> ListItems { get; set; }
        public static StoreCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<StoreDbContext>();
            string storeCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", storeCartId);

            return new StoreCart(context)
            {
                StoreCartId = storeCartId
            };
        }

        public void AddToCart(Car car)
        {
            this.storeDbContext.StoreCartItem.Add(new StoreCartItem
            {
                StoreCartId = StoreCartId,
                car = car,
                Price = car.Price,
                
            }) ;
            storeDbContext.SaveChanges();
        }
        public List<StoreCartItem> GetStoreItems()
        {
            return storeDbContext.StoreCartItem.Where(c => c.StoreCartId == StoreCartId).Include(x => x.car).ToList();
        }

    }
}
