using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class _OrderDetail
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; } // Liên kết với lớp Order

        public Guid ProductId { get; set; } // Liên kết với lớp Product

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string? CreatedBy { get; set; } // Nullable
        public string? LastUpdatedBy { get; set; } // Nullable
        public string? DeletedBy { get; set; } // Nullable

        public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset LastUpdatedTime { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? DeletedTime { get; set; } = DateTimeOffset.Now;

        public _OrderDetail(Guid id, Guid orderId, Guid productId, int quantity, decimal unitPrice, string? createdBy, string? lastUpdatedBy, string? deletedBy, DateTimeOffset createdTime, DateTimeOffset lastUpdatedTime, DateTimeOffset? deletedTime)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            CreatedBy = createdBy;
            LastUpdatedBy = lastUpdatedBy;
            DeletedBy = deletedBy;
            CreatedTime = createdTime;
            LastUpdatedTime = lastUpdatedTime;
            DeletedTime = deletedTime;
        }
    }
}
