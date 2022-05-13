using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EBlockbuster.Core.Entities
{
    [Table("Administrator")]
    public class Administrator
    {
        [Key]
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //FK Login
        public int LoginId { get; set; }
        public Login Login { get; set; }
    }
}
