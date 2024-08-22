using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Users")]

    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? BankAccount { get; set; }
        public string? BankAccountName { get; set; }
        public string? Bank { get; set; }
        public string? CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdatedTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        // Navigation properties
        public virtual ICollection<Order> CreatedOrders { get; set; } = new List<Order>();
        public virtual ICollection<Order> ProcessedOrders { get; set; } = new List<Order>();

        public virtual ICollection<Tasks> CreatedTasks { get; set; } = new List<Tasks>();
        public virtual ICollection<Tasks> AssignedTasks { get; set; } = new List<Tasks>();
    }
}
