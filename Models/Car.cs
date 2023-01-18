namespace Store.Models
{
    public class Car
    {
        public int Id { get; set; }         //  айди авто
        public string Name { get; set; }      //  название
        public string ShortDescription { get; set; }     //  описание  
        public string LongDescription { get; set; }
        public string Img { get; set; }          // фото товара  Url адрес
        public ushort Price { get; set; }            // ushort чтобы цены не были отрицательными
        public bool isFavourite { get; set; }      //  избранное
        public bool Available { get; set; }            // наличие авто в парке
        public int CategoryID { get; set; }         // категория автомобиля
        public virtual Category Category { get; set; }     // создаем объект определенной категории
    }
}
