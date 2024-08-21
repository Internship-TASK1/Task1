using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UserTemp
    {
        public static string Id { get; set; }
        public static string UserName { get; set; }

        public UserTemp(string id, string usName)
        {
            Id = id;
            UserName = usName;
        }
    }
}
