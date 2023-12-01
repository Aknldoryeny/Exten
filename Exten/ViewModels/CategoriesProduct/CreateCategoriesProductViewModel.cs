using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.CategoriesProduct
{
    public class CreateCategoriesProductViewModel
    {
        [Required(ErrorMessage = "Введите название категории товаров")]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
    }
}
