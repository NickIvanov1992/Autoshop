using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Memory
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new List<Order>();

        Order IOrderRepository.Create()
        {
            int nextId = orders.Count + 1;
            var order = new Order(nextId, new OrderItem[0]);
            orders.Add(order);
            return order;
        }

        Order IOrderRepository.GetById(int id)               // получить ссылку на заказ клиента
        {
            return orders.Single(order => order.Id == id);
        }

        void IOrderRepository.Update(Order order)
        {
            ;
        }
    }
}
