using Store.EF;
using Store.interfaces;
using Store.Models;

namespace Store.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly StoreDbContext storeDbContext;
        private readonly StoreCart storeCart;
        public OrdersRepository(StoreDbContext storeDbContext, StoreCart storeCart)
        {
            this.storeDbContext = storeDbContext;
            this.storeCart = storeCart;
        }
        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            storeDbContext.Order.Add(order);
            storeDbContext.SaveChanges();
            var items = storeCart.ListItems;
            foreach(var v in items)
            {
                var orderDetails = new OrderDetails()
                {
                    CarId = v.car.Id,
                    OrderId = order.Id,
                    Price = v.car.Price  
                };
                storeDbContext.OrderDetails.Add(orderDetails);  
                v.car.Available = v.car.Available - 1;  // удаляем из парка 1 автомобиль
            }
            storeDbContext.SaveChanges();
                
        }
    }
}
