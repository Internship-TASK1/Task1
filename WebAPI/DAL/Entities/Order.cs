using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Orders")]
    public class Order
    {
        public Guid Id { get; set; }
        public string? CreatedByUserId { get; set; } // Updated from Guid to string
        public string? ProcessedByUserId { get; set; } // Updated from Guid to string
        public DateTimeOffset OrderDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        // Navigation properties
        [ForeignKey("CreatedByUserId")]
        public ApplicationUser? CreatedByUser { get; set; }

        [ForeignKey("ProcessedByUserId")]
        public ApplicationUser? ProcessedByUser { get; set; }

        // Foreign Key properties
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public Order()
        {
            CreatedBy = string.Empty;
            LastUpdatedBy = string.Empty;
            DeletedBy = string.Empty;
        }

        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
