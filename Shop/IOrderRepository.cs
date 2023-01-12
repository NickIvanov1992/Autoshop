using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public interface IOrderRepository
    {
        Order Create();   // создает заказ
        Order GetById(int id);     // идентификатор заказа
        void Update(Order order);     // обновить заказ
    }
}
