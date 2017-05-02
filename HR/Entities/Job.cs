using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRuwp.Entities
{
    public class Job
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public double Pay { get; set; }
        public string Grade { get; set; }

        public override string ToString()
        {
            return this.Name;

        }

    }

    
}
