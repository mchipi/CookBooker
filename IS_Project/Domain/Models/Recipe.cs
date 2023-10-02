using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MinLength(100)]
        public string Description { get; set; }
        [Required]
        [MinLength(100)]
        public string Instructions { get; set; }
        [Required]
        public int CookingTime { get; set; }
        [Required]
        public int Servings { get; set; }


    }
}
