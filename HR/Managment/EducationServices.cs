using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class EducationServices
    {
        Model_HR db = new Model_HR();
        public EducationServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(Education x)
        {
            db.Educations.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Education x)
        {
            var Origin = db.Educations.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Educations.Remove(db.Educations.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Education> ListEducations()
        {
            return db.Educations.ToList();
        }

        public Education FindExisting(int id)
        {
            var Origin = db.Educations.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
