using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment
{
    public static class DataBaseService
    {
        public static Model_HR DB = new Model_HR();

        public static int SaveChanges()
        {
            return DB.SaveChanges();
        }
    }
}
