using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRuwp.Entities
{
    public class Departement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }
        public string Contry { get; set; }
        public Departement ParentDepartment { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
