using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    public class NationalitiesServices
    {
        Model_HR db = new Model_HR();
        public NationalitiesServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(Nationality Nat)
        {
            db.Nationalities.Add(Nat);
            return db.SaveChanges() > 0;
        }

        public bool Update(Nationality Nat)
        {
            Nationality Origin = db.Nationalities.Find(Nat.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Nat);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete (int id)
        {
            db.Nationalities.Remove(db.Nationalities.Find(id));
            return db.SaveChanges() > 0;
        } 

        public Nationality FindExisting(int id)
        {
            Nationality Origin = db.Nationalities.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }

        public List<Nationality> ListNationalities()
        {
            return db.Nationalities.ToList();
        }
    }
}
