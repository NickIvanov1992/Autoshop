using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }         //  айди авто
        [Display(Name = "Название")]
        public string Name { get; set; }      //  название
        [Display(Name = "Краткое описание")]
        public string ShortDescription { get; set; }     //  описание

        [Display(Name = "Полное описание")]                                                //  
        public string LongDescription { get; set; }
        [Display(Name = "Изображение")]
        public string Img { get; set; }          // фото товара  Url адрес
        [Display(Name = "Цена")]
        public ushort Price { get; set; }            // ushort чтобы цены не были отрицательными
        [Display(Name = "Рекомендация")]
        public bool isFavourite { get; set; }      //  избранное
        public bool Available { get; set; }            // наличие авто в парке
        //[Display(Name = "тип ТС (1 - грузовик; 2- легковой авто")]
        public int CategoryID { get; set; }         // категория автомобиля
       // public virtual Category Category { get; set; }     // создаем объект определенной категории
    }
}
