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

        public async Task<ICollection<Employee>> GetManagerSubordinates(int managerId)
        {
            var employees = await dbContext.Employees.Where(x => x.ManagerId == managerId).ToListAsync();
            foreach (var employee in employees)
            {
                employee.Reports = await dbContext.Reports.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
                employee.CustomTasks = await dbContext.CustomTasks.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
            }
            return employees;
        }
    }
        
}
