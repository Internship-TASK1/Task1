using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    [Table("Tasks")]
    public class Tasks
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public DateTimeOffset CreatedTime { get; set; }

        [Required]
        public Guid AssignedToUserId { get; set; }

        [Required]
        public Guid CreatedByUserId { get; set; }

        public string? Description { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        [ForeignKey("AssignedToUserId")]
        public User? AssignedToUser { get; set; }

        [ForeignKey("CreatedByUserId")]
        public User? CreatedByUser { get; set; }
    }
}
