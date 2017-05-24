using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Entities;

namespace HR.Managment
{
    class ClientsServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Client x)
        {
            db.Clients.Add(x);
            return db.SaveChanges() > 0;
        }

        public bool Update(Client x)
        {
            var Origin = db.Clients.Find(x.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(x);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Clients.Remove(db.Clients.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Client> ListClients()
        {
            return db.Clients.ToList();
        }

        public Client FindExisting(int id)
        {
            var Origin = db.Clients.FirstOrDefault(c => c.Id == id);
            //db.Entry(Origin).State = System.Data.Entity.EntityState.Modified;
            return Origin;
        }
    }
}
