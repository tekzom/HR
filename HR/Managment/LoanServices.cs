using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRuwp.Entities;

namespace HR.Managment
{
    class LoanServices
    {

        Model_HR db = new Model_HR();

        public bool Add(Loan Lo)
        {
            db.Loans.Add(Lo);
            return db.SaveChanges() > 0;
        }

        public bool Update(Loan Lo)
        {
            Loan Origin = db.Loans.Find(Lo.Id);
            if (Origin != null)
            {
                db.Entry(Origin).CurrentValues.SetValues(Lo);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            db.Loans.Remove(db.Loans.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Loan> ListLoans()
        {
            return db.Loans.ToList();
        }
    }
}
