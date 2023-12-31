﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exten.Models.Data
{
    public class User : IdentityUser
    {
/*        [Required]
        [Display(Name = "Логин")]
        public DateTime login { get; set; }*/

        [Required]
        [Display(Name = "Дата регистрации")]
        public DateTime RegistrationDate { get; set; }

        // Навигационные свойства
        public ICollection<Forum> Forum { get; set; }
    }
}
