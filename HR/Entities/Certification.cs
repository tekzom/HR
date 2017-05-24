using HRuwp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities
{
    public class Certification
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }

        public override string ToString()
        {
            return this.Name;

        }
    }
}
