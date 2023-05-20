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
            var employees = await dbContext.Employees.ToListAsync();
            foreach (var employee in employees)
            {
                employee.CustomTasks = await dbContext.CustomTasks.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
                employee.Reports = await dbContext.Reports.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
            }
            return employees;
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            Employee employee = new();
            employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (employee != null)
            {
                employee.CustomTasks = await dbContext.CustomTasks.Where(x => x.EmployeeId == employeeId).ToListAsync();
                employee.Reports = await dbContext.Reports.Where(x => x.EmployeeId == employeeId).ToListAsync();
                var manager = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.ManagerId);
                if (manager != null)
                {
                    employee.ManagerFullName = manager.FirstName + " " + manager.LastName;
                }
            }
            return employee;
        }

        public async Task<Employee> GetCustomTasksByEmployee(int employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            employee.CustomTasks = await dbContext.CustomTasks.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
            return employee;
        }

        public async Task<ICollection<Employee>> GetReportsFromSubordinates(int managerId)
        {
            var employees = await dbContext.Employees.Where(x => x.ManagerId == managerId).ToListAsync();
            foreach (var employee in employees)
            {
                employee.Reports = await dbContext.Reports.Where(x => x.EmployeeId == employee.EmployeeId).ToListAsync();
            }
            return employees;
        }

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }

    }
}
