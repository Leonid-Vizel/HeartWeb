using HeartWeb.Instruments;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeartWeb.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Укажите логин!")]
        [EmailAddress(ErrorMessage = "Неверный формат почты!")]
        [DisplayName("Почта")]
        public string Login { get; set; } = null!;
        [Required(ErrorMessage = "Укажите пароль!")]
        [MinLength(6, ErrorMessage = "Минимальный размер пароля: 6 символов!")]
        [MaxLength(100, ErrorMessage = "Максимальный размер пароля: 100 символов!")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Укажите название организации!")]
        [MinLength(1, ErrorMessage = "Минимальный размер названия: 1 символ!")]
        [MaxLength(200, ErrorMessage = "Максимальный размер названия: 200 символов!")]
        [DisplayName("Название организации")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите номер телефона!")]
        [MinLength(1, ErrorMessage = "Минимальный размер телефонного номера: 1 символ!")]
        [MaxLength(16, ErrorMessage = "Максимальный размер телефонного номера: 16 символов!")]
        [DisplayName("Контактный номер телефона")]
        [Phone(ErrorMessage = "Неверный формат номера телефона!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Укажите регион пользователя!")]
        [MinLength(1, ErrorMessage = "Минимальный размер региона: 1 символ!")]
        [MaxLength(100, ErrorMessage = "Максимальный размер региона: 100 символов!")]
        [DisplayName("Регион")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Укажите откуда пользователь!")]
        [Range(0, 1, ErrorMessage = "Укажите откуда пользователь!")]
        [DisplayName("Откуда пользователь?")]
        public int IsFromCity { get; set; }

        public User ToUser()
        {
            return new User()
            {
                Login = Login,
                Password = Hasher.ComputeHash(Login, Password),
                Name = Name,
                Phone = Phone,
                Region = Region,
                IsFromCity = IsFromCity == 1,
            };
        }
    }
}
