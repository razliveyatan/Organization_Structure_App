using DAL.Types;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<ICollection<CustomTask>> GetCustomTasksByEmployee(int employeeId)
        {
            return await dbContext.CustomTasks.Where(x => x.EmployeeId == employeeId).ToListAsync();
        }

        public async Task<ICollection<Report>> GetReportsFromSubordinates(int managerId)
        {
            return await dbContext.Reports.Where(x => x.ManagerId == managerId).ToListAsync();
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }


    }
}
