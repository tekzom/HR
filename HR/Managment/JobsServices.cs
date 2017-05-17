using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class JobsServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Job Jb)
        {
            db.Jobs.Add(Jb);
            return db.SaveChanges() > 0;
        }

        public bool Update(Job Jb)
        {
            Job Origin = db.Jobs.Find(Jb.Code);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Jb);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Jobs.Remove(db.Jobs.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Job> ListJobs()
        {
            return db.Jobs.ToList();
        }

        public Job FindExisting(int id)
        {
            Job Origin = db.Jobs.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
