using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class EmployeeRepository
    {
        private readonly Org_Structure_DbContext dbContext;

        public EmployeeRepository(Org_Structure_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }   

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }


    }
}
