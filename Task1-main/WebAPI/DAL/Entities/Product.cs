﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }

        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; } // Nullable

        [Required]
        public DateTimeOffset CreatedTime { get; set; }

        [Required]
        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; }

        // Constructor
        public Product()
        {
            // Initialize required properties
            Name = string.Empty;
            Description = string.Empty;
            CreatedBy = string.Empty;
            LastUpdatedBy = string.Empty;
            DeletedBy = string.Empty;

            // Assign a new GUID as the ID
            Id = Guid.NewGuid();
        }
    }
}
