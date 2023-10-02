using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        

    }
}
