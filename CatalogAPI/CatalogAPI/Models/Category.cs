using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CatalogAPI.Validations;

namespace CatalogAPI.Models
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [NameValidation]
        public string Name { get; set; }

        [Required] [MaxLength(300)] public string ImageUrl { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}