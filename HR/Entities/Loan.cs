using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRuwp.Entities
{
    public class Loan
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Loaloanstart { get; set; }
        public DateTime Deadline { get; set; }
        public string Anount { get; set; }
        public string Statut { get; set; }
    }
}
