using Exten.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.Forum
{
    public class CreateForumViewModel
    {
        //key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкриментное

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

        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public string IdUser { get; set; }


    }
}
