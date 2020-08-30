using CatalogAPI.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Models
{
    public class Product : IValidatableObject
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        [NameValidation]
        public string Name { get; set; }

        [Required] [MaxLength(300)] public string Description { get; set; }

        [Required] public decimal Price { get; set; }

        [Required] [MaxLength(500)] public string ImageUrl { get; set; }

        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stock <= 0)
            {
                yield return new ValidationResult("O estoque deve ser maior do que zero", new[] { nameof(Stock) });
            }
        }
    }
}