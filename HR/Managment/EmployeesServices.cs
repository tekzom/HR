using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class EmployeesServices
    {
        Model_HR db = new Model_HR();
        public EmployeesServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(Employee Em)
        {
            db.Employees.Add(Em);
            return db.SaveChanges() > 0;
        }

        public bool Update(Employee Em)
        {
            Employee Origin = db.Employees.Find(Em.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Em);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Employees.Remove(db.Employees.Find(id));
            return db.SaveChanges() > 0;
        }

        public Employee FindExisting(int id)
        {
            Employee Origin = db.Employees.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }

    

        public List<Employee> ListEmployees()
        {
            return db.Employees.ToList();
        }

        public bool FindUser (string u)
        {
            var employee = (from e in db.Employees where (e.FirstName == u) select e).FirstOrDefault();
            if (employee != null)
                return true;
            return false;
        }

        public bool FindPass(string u, string p)
        {
            var employee = (from e in db.Employees where (e.FirstName == u && e.password == p) select e).FirstOrDefault();
            if (employee != null)
                return true;
            return false;
        }
    }
}
