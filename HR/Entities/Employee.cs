using HR.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRuwp.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nationality Nation { get; set; }
        public DateTime Datebirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string CIN { get; set; }
        public string EpmloyeeStatus { get; set; }
        public Job Job { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public Departement Dep { get; set; }
        public Employee Supervisor { get; set; }
        public Status Stat { get; set; }
        public PayGrade pay { get; set; }


        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
