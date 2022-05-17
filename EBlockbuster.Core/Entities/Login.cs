using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlockbuster.Core.Entities
{
    [Table("Login")]
    public class Login
    {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int SecurityLevelId { get; set; }
        
        public SecurityLevel SecurityLevel { get; set; }

    }
}
