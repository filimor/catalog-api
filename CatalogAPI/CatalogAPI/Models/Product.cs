using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CatalogAPI.Validations;

namespace CatalogAPI.Models
{
    [Table("Products")]
    public class Product : IValidatableObject
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O nome deve ter entre {2} e {1} caracteres", MinimumLength = 5)]
        [NameValidation]
        public string Name { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "A descrição deve ter no máximo {1} caracteres")]
        public string Description { get; set; }

        [Required] public decimal Price { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "A URL não pode ultrapassar 300 caracteres")]
        public string ImageUrl { get; set; }

        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Stock <= 0)
            {
                yield return new ValidationResult("O estoque deve ser maior do que zero", new[] {nameof(Stock)});
            }

            if (Price <= 0)
            {
                yield return new ValidationResult("O preço deve ser maior do que zero", new[] {nameof(Price)});
            }
        }
    }
}