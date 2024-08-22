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

        public string User { get; set; } = string.Empty;

        public DateTimeOffset Deadline { get; set; }
    }
}
