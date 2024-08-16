using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Orders")]

    public class Order
    {
      
            public Guid Id { get; set; }

            [Required]
            public Guid UserId { get; set; }

            [Required]
            public DateTimeOffset OrderDate { get; set; }

            public string? CreatedBy { get; set; }
            public string? LastUpdatedBy { get; set; }
            public string? DeletedBy { get; set; }
            public DateTimeOffset CreatedTime { get; set; }
            public DateTimeOffset LastUpdatedTime { get; set; }
            public DateTimeOffset? DeletedTime { get; set; }

            // Navigation properties
            public User? CreatedByUser { get; set; }
            public User? ProcessedByUser { get; set; }

            // Foreign Key properties
            public Guid? CreatedByUserId { get; set; }
            public Guid? ProcessedByUserId { get; set; }

            public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

            public Order()
            {
                CreatedBy = string.Empty;
                LastUpdatedBy = string.Empty;
                DeletedBy = string.Empty;
            }
        }
    }
    

