using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
