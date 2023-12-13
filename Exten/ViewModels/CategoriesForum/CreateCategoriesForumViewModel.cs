using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.CategoriesForum
{
    public class CreateCategoriesForumViewModel
    {
        [Required(ErrorMessage = "Введите название категории форума")]
        [Display(Name = "Категория Форума")]
        public string ForumCategoryName { get; set; }
    }
}