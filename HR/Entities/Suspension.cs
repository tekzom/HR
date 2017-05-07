using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRuwp.Entities
{
    public class Suspension
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateD { get; set; }
        public DateTime DateF { get; set; }
        public Employee Employee { get; set; }

        public override string ToString()
        {
            return this.Id.ToString();
        }
    }
}
