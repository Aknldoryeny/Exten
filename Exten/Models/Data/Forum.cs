﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exten.Models.Data
{
    public class Forum
    {
        //key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкриментное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Введите тему форума")]
        [Display(Name = "Тема форума")]
        public string ForumTopic { get; set; }

        [Display(Name = "Сообщение на форуме")]
        public decimal ForumMessage { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        public DateTime DateCreation { get; set; }

        [Required]
        [Display(Name = "Выберите категорию форума")]
        public short IdCategoryForum { get; set; }


        // Навигационные свойства
        [Display(Name = "Категория форума")]
        [ForeignKey("IdCategoryForum")]
        public CategoriesForum CategoriesForum { get; set; }

        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public string IdUser { get; set; }


        // Навигационные свойства
        [Display(Name = "Идентификатор пользователя")]
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}