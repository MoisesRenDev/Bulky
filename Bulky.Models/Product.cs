using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [StringLength(150, ErrorMessage = "El título es demasiado largo")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es requerido")]
        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es requerido")]
        public string ISBN { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es requerido")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es requerido")]
        [Range(1,1000, ErrorMessage = "Valor fuera de rango")]
        [Display(Name = "Precio de Lista")]
        public double PriceList { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        [Range(1, 1000, ErrorMessage = "Valor fuera de rango")]
        [Display(Name = "Precio de 1-50")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "Es requerido")]
        [Range(1, 1000, ErrorMessage = "Valor fuera de rango")]
        [Display(Name = "Precio de 50+")]
        public double Price50 { get; set; }
        
        [Required(ErrorMessage = "Es requerido")]
        [Range(1, 1000, ErrorMessage = "Valor fuera de rango")]
        [Display(Name = "Precio de 100+")]
        public double Price100 { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }

        //Adding the relations}
        [Required(ErrorMessage = "Es requerido")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}
