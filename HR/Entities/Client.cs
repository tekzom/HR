using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyUrl { get; set; }
        public string Status { get; set; }
        public DateTime FirstContact { get; set; }

        public override string ToString()
        {
            return this.Name;

        }
    }
}
