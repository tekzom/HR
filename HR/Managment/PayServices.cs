using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class PayServices
    {
        Model_HR db = new Model_HR();
        public PayServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(PayGrade PG)
        {
            db.PayGrades.Add(PG);
            return db.SaveChanges() > 0;
        }

        public bool Update(PayGrade PG)
        {
            PayGrade Origin = db.PayGrades.Find(PG.Code);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(PG);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int Code)
        {
            db.PayGrades.Remove(db.PayGrades.Find(Code));
            return db.SaveChanges() > 0;
        }

        public PayGrade FindExisting(int id)
        {
            PayGrade Origin = db.PayGrades.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }

        public List<PayGrade> ListPaygrades()
        {
            return db.PayGrades.ToList();
        }
    }
}
