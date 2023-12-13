using System.ComponentModel.DataAnnotations;

namespace Exten.ViewModels.Product
{
    public class EditProductViewModel
    {
        [Required(ErrorMessage = "Введите название товара")]
        [Display(Name = "Название товара")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Введите цену на товар")]
        [Display(Name = "Цена товара")]
        public decimal PriceProduct { get; set; }

        [Display(Name = "Описание товара")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Выберите категорию товара")]
        public short IdCategoryProduct { get; set; }
    }
}
