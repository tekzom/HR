using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class HolidaysServices
    {
        Model_HR db = new Model_HR();

        public bool Add(Holiday Hl)
        {
            db.Holidays.Add(Hl);
            return db.SaveChanges() > 0;
        }

        public bool Update(Holiday Hl)
        {
            Holiday Origin = db.Holidays.Find(Hl.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Hl);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Holidays.Remove(db.Holidays.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Holiday> ListHolidayss()
        {
            return db.Holidays.ToList();
        }
    }
}
