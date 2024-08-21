using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class JobsModel
    {
        public Guid OrderDetailID { get; set; }

        public Guid UserID { get; set; }

        public DateTimeOffset Deadline { get; set; }

        public JobsModel( Guid UserID, DateTimeOffset Deadline) {
            this.OrderDetailID = OrderDetailID;
            this.UserID = UserID;
            this.Deadline = Deadline;
        }
    }
}
