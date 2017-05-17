using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Entities
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        public Project Proj { get; set; }
        public Employee Empl { get; set; }
        public string Details { get; set; }
        
    }
}
