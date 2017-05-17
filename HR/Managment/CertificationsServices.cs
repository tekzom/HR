using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class CertificationsServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Certification x)
        {
            db.Certifications.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Certification x)
        {
            var Origin = db.Certifications.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Certifications.Remove(db.Certifications.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Certification> ListCertifications()
        {
            return db.Certifications.ToList();
        }

        public Certification FindExisting(int id)
        {
            var Origin = db.Certifications.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
