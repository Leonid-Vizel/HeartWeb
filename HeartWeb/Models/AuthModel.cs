using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HeartWeb.Models
{
    public class AuthModel
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
    }
}
