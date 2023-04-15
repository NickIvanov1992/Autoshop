using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(40)]
        [Required(ErrorMessage = "Введите имя!")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(40)]
        [Required(ErrorMessage = "Введите фамилию!")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(40)]
        [Required(ErrorMessage = "Введите адрес!")]
        public string Adress { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Некорректный номер!")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(40)]
        [Required(ErrorMessage = "Неверный Email")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

    }
}
