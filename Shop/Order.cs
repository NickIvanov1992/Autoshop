using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Order
    {
        public int Id { get; }        //    идентификатор заказа

        private List<OrderItem> items;    // список
        public IReadOnlyCollection<OrderItem> Items    // массив который нельзя изменить внешне
        {
            get { return items; }
        }
        public OrderItem GetItem(int carId)
        {
            int index = items.FindIndex(item => item.CarId == carId);
            if (index == -1)
                ThrowCarException("Car not found.", carId);

            return items[index];
        }
        public void AddCar(Car car)
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            AddOrUpdateItem(car, 1);
        }
        public void RemoveItem(int carId)
        {
            int index = items.FindIndex(item => item.CarId == carId);

            if (index == -1)
                ThrowCarException("Order does not contain specified item.", carId);

            items.RemoveAt(index);
        }

        public void RemoveCar(Car car)
        {

            if (car == null)
                throw new ArgumentNullException(nameof(car));

            AddOrUpdateItem(car, -1);
        }
        public int TotalCount     // всего тестдрайвов
        {
            get { return items.Sum(item => item.Count); }
        }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            Id = id;
            this.items = new List<OrderItem> (items);
        }

        public void AddOrUpdateItem(Car car, int count)    // count - количество авто
        {
            if (car == null)
                throw new ArgumentNullException(nameof(car));   // проверка существования обьявления

            // вернуть ID обьявления
            int index = items.FindIndex(item => item.CarId == car.Id);
            if (index == -1)
                items.Add(new OrderItem(car.Id, count, car.Price));
            else
                items[index].Count += count;
        }
        private void ThrowCarException(string message, int carId)
        {
            var exception = new InvalidOperationException(message);

            exception.Data["CarId"] = carId;

            throw exception;
        }
    }
}
