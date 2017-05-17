using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HR.Entities
{
    public class PayGrade
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return this.Name;

        }
    }
}
