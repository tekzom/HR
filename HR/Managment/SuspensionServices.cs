using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class SuspensionServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Suspension Sus)
        {
            db.Suspensions.Add(Sus);
            return db.SaveChanges() > 0;
        }

        public bool Update(Suspension Sus)
        {
            Suspension  Origin = db.Suspensions.Find(Sus.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Sus);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Suspensions.Remove(db.Suspensions.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Suspension> ListSuspensions()
        {
            return db.Suspensions.ToList();
        }
    }
}
