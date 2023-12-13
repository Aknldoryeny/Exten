using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.CategoriesForum
{
    public class EditCategoryForumViewModel
    {
        public short Id { get; set; }
        [Required(ErrorMessage = "Введите название категории форума")]
        [Display(Name = "Категория Форума")]
        public string ForumCategoryName { get; set; }
    }
}
