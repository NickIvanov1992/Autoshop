using System.Text.RegularExpressions;

namespace Shop
{
    public class Car
    {
        public int Id { get; }
        public string Year { get; }     // год выпуска авто
        public string Brand { get; }
        public string Model { get; }
        public string Description { get; }   // описание
        public decimal Price { get; }        // цена авто
        public Car(int id, string model, string brand, string year, string description, decimal price)
        {
            Model = model;
            Id = id;
            Brand = brand;
            Year = year;
            Description = description;
            Price = price;
        }

        internal static bool IsYear(string str)    // проверка введенного года выпуска
        {
            if (str == null)    // попроюовать добавить из нул!!!
                return false;

            str = str.Replace("-", "")      // дефис и пробел заменить на пустую строку при наличии
                .Replace(" ", "")
                .ToUpper();              // установить верхний регистр

            return Regex.IsMatch(str, @"^YEAR\d{10}(\d{3})?$");       //  регулярное выражение 4 цифры в написании года (название Year должно быть в начале) после цифры - конец строки
        }

    }
}