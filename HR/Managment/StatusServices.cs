using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class StatusServices
    {
        Model_HR db = new Model_HR();
        public StatusServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(Status St)
        {
            db.Statuss.Add(St);
            return db.SaveChanges() > 0;
        }

        public bool Update(Status St)
        {
            Status Origin = db.Statuss.Find(St.ID);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(St);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Statuss.Remove(db.Statuss.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Status> ListStatus()
        {
            return db.Statuss.ToList();
        }

        public Status FindExisting(int id)
        {
            Status Origin = db.Statuss.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
