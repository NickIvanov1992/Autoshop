using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;



namespace Shop.Domain
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

        [Display(Name = "Изображение")]
        
        public byte[]? Img { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена не соответствует")]
        public int Price { get; set; }            

        [Display(Name = "Рекомендация")]
        [Required(ErrorMessage = "True либо False")]
        public bool isFavourite { get; set; }      //  избранное
        [Display(Name = "Наличие авто в парке")]
        public int Available { get; set; }            // наличие авто в парке

        [Display(Name = "Категория ТС")]
        [Required(ErrorMessage = "Отсутствует категория ТС")]
        public int CategoryID { get; set; }         // категория автомобиля


    }
}
