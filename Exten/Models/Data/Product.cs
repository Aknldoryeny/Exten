using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exten.Models.Data
{
    public class Product
    {
        //key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкриментное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

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


        // Навигационные свойства
        [Display(Name = "Категория товаров")]
        [ForeignKey("IdCategoryProduct")]
        public CategoryProduct CategoryProduct { get; set; }

    }
}
