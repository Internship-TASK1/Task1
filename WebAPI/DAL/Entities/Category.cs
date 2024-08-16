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
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdatedBy { get; set; }

        public string DeletedBy { get; set; }

        public DateTimeOffset CreatedTime { get; set; }

        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; }

        // Constructor to initialize non-nullable properties
        public Category()
        {
            Name = string.Empty;
            Description = string.Empty;
            CreatedBy = string.Empty;
            LastUpdatedBy = string.Empty;
            DeletedBy = string.Empty;
        }
    }
}
