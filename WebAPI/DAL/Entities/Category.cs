using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Categories")]

    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } // Nullable

        [MaxLength(500)]
        public string? Description { get; set; } // Nullable

        public string? CreatedBy { get; set; } // Nullable

        public string? LastUpdatedBy { get; set; } // Nullable

        public string? DeletedBy { get; set; } // Nullable

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; } // Nullable

        // Constructor to initialize nullable properties
        public Category()
        {
            Name = null;
            Description = null;
            CreatedBy = null;
            LastUpdatedBy = null;
            DeletedBy = null;
        }
    }
}
