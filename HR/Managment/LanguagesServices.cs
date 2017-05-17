using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class LanguagesServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Language x)
        {
            db.Languages.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Language x)
        {
            var Origin = db.Languages.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Languages.Remove(db.Languages.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Language> ListLanguages()
        {
            return db.Languages.ToList();
        }

        public Language FindExisting(int id)
        {
            var Origin = db.Languages.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
