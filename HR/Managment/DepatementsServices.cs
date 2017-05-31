using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class DepatementsServices
    {
        Model_HR db = new Model_HR();
        public DepatementsServices()
        {
            db = DataBaseService.DB;
        }

        public bool Add(Departement Dp)
        {
            db.Departements.Add(Dp);
            return db.SaveChanges() > 0;
        }

        public bool Update(Departement Dp)
        {
            Departement Origin = db.Departements.Find(Dp.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Dp);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Departements.Remove(db.Departements.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Departement> ListDepartements()
        {
            return db.Departements.ToList();
        }

        public Departement FindExisting(int id)
        {
            Departement Origin = db.Departements.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
