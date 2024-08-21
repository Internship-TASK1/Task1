using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Login
    {
         public string Username { get; set; } = string.Empty;
         public string Password { get; set; } = string.Empty;

    }
}
