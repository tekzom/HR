using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class LeavesServices
    {
        Model_HR db = new Model_HR();
        public LeavesServices()
        {
            db = DataBaseService.DB;
        }
        public bool Add(Leaves Le)
        {
            db.Leaves.Add(Le);
            return db.SaveChanges() > 0;
        }

        public bool Update(Leaves Le)
        {
            Leaves Origin = db.Leaves.Find(Le.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Le);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Leaves.Remove(db.Leaves.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Leaves> ListLeaves()
        {
            return db.Leaves.ToList();
        }
    }
}
