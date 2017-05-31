using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR;
using HR.Entities;

namespace HR.Managment
{
    class ProjectsServices
    {
        public ProjectsServices()
        {
            db = DataBaseService.DB;
        }

        Model_HR db = new Model_HR();

        public bool Add(Project x)
        {
            db.Projects.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Project x)
        {
            var Origin = db.Projects.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Projects.Remove(db.Projects.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Project> ListProjects()
        {
            return db.Projects.ToList();
        }

        public Project FindExisting(int id)
        {
            var Origin = db.Projects.Find(id);
            db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
