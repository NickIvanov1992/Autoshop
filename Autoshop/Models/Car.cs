using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Store.Models
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }         //  айди авто

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Отсутствует название")]
        public string Name { get; set; }      //  название

        [Display(Name = "Краткое описание")]
        [Required(ErrorMessage = "Отсутствует краткое описание")]
        public string ShortDescription { get; set; }     //  описание

        [Display(Name = "Полное описание")]
        [Required(ErrorMessage = "Отсутствует полное описание")]  
        public string LongDescription { get; set; }

        [Display(Name = "Изображение")]
       // [Required(ErrorMessage = "Отсутствует изображение")]
       // public string Img { get; set; }          // фото товара  Url адрес

        public byte[]? Img { get; set; }
  //      [Required]
    //    public string? ImgMimeType { get; set; } 

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена не соответствует")]
        public int Price { get; set; }            // ushort чтобы цены не были отрицательными

        [Display(Name = "Рекомендация")]
        [Required(ErrorMessage = "True либо False")]
        public bool isFavourite { get; set; }      //  избранное
        [Display(Name = "Наличие авто в парке")]
        
        public int Available { get; set; }            // наличие авто в парке

        [Display(Name = "Категория ТС(1 - грузовой 2-легковой)")]
        [Required(ErrorMessage = "Отсутствует категория ТС")]
        public int CategoryID { get; set; }         // категория автомобиля
       // public virtual Category Category { get; set; }     // создаем объект определенной категории
    }
}
