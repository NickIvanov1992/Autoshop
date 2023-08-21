using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain;

namespace Shop.Data.EF
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
        public async Task <List<StoreCartItem>> GetStoreItems()
        {
            return await storeDbContext.StoreCartItem.Where(c => c.StoreCartId == StoreCartId).Include(x => x.car).ToListAsync();
        }
        public void RemoveCar(StoreCartItem deleteItem)
        {
            storeDbContext.StoreCartItem.Remove(deleteItem);
            storeDbContext.SaveChanges();
        }
        

    }
}
