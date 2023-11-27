using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exten.Models.Data
{
    public class CategoryProduct
    {
        //key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкриментное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]

        public short Id { get; set; }

        [Required(ErrorMessage = "Введите название категории товаров")]
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }
    }
}
