namespace Store.ViewModels
{
    public class EditCarViewModel
    {
        public int Id { get; set; }         //  айди авто
        public string Name { get; set; }      //  название
        public string ShortDescription { get; set; }     //  описание  
        public string Img { get; set; }          // фото товара  Url адрес
        public ushort Price { get; set; }           
        public bool isFavourite { get; set; }      //  избранное
                    // наличие авто в парке
        public int CategoryID { get; set; }         // категория автомобиля
    }
}
