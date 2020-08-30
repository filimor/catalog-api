using CatalogAPI.Validations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo {1} caracteres")]
        [NameValidation]
        public string Name { get; set; }

        [Required] [MaxLength(300, ErrorMessage = "A URL não pode ultrapassar 300 caracteres")] public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}