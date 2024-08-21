using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class UserTemp
    {
        public static string Id { get; set; } = string.Empty;
        public static string UserName { get; set; } = string.Empty;



        public UserTemp(string id, string usName)
        {
            Id = id;
            UserName = usName;
        }
    }
}
