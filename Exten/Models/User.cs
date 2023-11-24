using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exten.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Введите логин")]

        //отображение Фамилия вместо Login
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]

        //отображение Фамилия вместо Password
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите почту")]

        //отображение Фамилия вместо Email
        [Display(Name = "Пароль")]
        public string Email { get; set; }
        //навигационные свойства
    }
}
