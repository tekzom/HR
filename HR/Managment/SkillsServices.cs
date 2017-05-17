using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class SkillsServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Skill x)
        {
            db.Skills.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Skill x)
        {
            var Origin = db.Skills.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Skills.Remove(db.Skills.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Skill> ListSkills()
        {
            return db.Skills.ToList();
        }

        public Skill FindExisting(int id)
        {
            var Origin = db.Skills.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
