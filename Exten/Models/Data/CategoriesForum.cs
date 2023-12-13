using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exten.Models.Data
{
    public class CategoriesForum
    {
        //key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкриментное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]

        public short Id { get; set; }

        [Required(ErrorMessage = "Введите название категории форума")]
        [Display(Name = "Категория Форума")]
        public string ForumCategoryName { get; set; }
        // Навигационные свойства
        public ICollection<Forum> Forum { get; set; }
    }
}
