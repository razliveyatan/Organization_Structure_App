using DAL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ManagerRepository
    {
        private readonly Org_Structure_DbContext dbContext;

        public ManagerRepository(Org_Structure_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
        
}
