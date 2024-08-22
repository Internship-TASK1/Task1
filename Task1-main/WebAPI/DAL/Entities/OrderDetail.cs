using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderId { get; set; } // Liên kết với lớp Order

        [Required]
        public Guid ProductId { get; set; } // Liên kết với lớp Product

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public string? CreatedBy { get; set; } // Nullable
        public string? LastUpdatedBy { get; set; } // Nullable
        public string? DeletedBy { get; set; } // Nullable

        [Required]
        public DateTimeOffset CreatedTime { get; set; }

        [Required]
        public DateTimeOffset LastUpdatedTime { get; set; }

        public DateTimeOffset? DeletedTime { get; set; } // Nullable

        // Navigation properties
        public Order? Order { get; set; } // Nullable
        public Product? Product { get; set; } // Nullable

        // Constructor
        public OrderDetail()
        {
            CreatedBy = string.Empty;
            LastUpdatedBy = string.Empty;
            DeletedBy = string.Empty;
        }
    }
}
