﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CatalogAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required] [MaxLength(80)] public string Name { get; set; }

        [Required] [MaxLength(300)] public string Description { get; set; }

        [Required] public decimal Price { get; set; }

        [Required] [MaxLength(500)] public string ImageUrl { get; set; }

        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}