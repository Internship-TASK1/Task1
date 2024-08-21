using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table("Jobs")]
    public class Jobs
    {
        [Key]
        public Guid Id { get; set; }

        public Guid OrderDetailID { get; set; }

        public Guid UserID { get; set; }

        public DateTimeOffset Deadline { get; set; }

        // Navigation properties (these can be left as they are)
        [ForeignKey("OrderDetailID")]
        public OrderDetail? OrderDetail { get; set; }

        [ForeignKey("UserID")]
        public User? User { get; set; }
    }
}
