using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR;
using HRuwp.Entities;

namespace HR.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Client Clie { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public virtual List<Employee> Employees { get; set; }



        public override string ToString()
        {
            return this.Name;

        }

    }
}
