using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("First_Name")]
        public string firstName { get; set; }

        [Column("Last_Name")]
        public string lastName { get; set; }
    }
}
