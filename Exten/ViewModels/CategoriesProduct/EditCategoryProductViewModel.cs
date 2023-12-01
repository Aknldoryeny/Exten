using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.CategoriesProduct
{
    public class EditCategoryProductViewModel
    {

        public short Id { get; set; }
        [Required(ErrorMessage = "Введите название категории товаров")]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
    }
}
