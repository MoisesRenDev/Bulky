using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Es Requerido")]
        [StringLength(50)]
        [DisplayName("Nombre de Categoría")]
        public string Name { get; set; } = string.Empty;
        [DisplayName("Orden de Categoría")]
        [Required(ErrorMessage = "Orden de Categoría")]
        [Range(1, 9999, ErrorMessage = "Valor fuera del rango")]
        public int DisplayOrder { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
    }
}
