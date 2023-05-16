using BL.IServices;
using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class EmployeeService : IEmployeeService
    {
        public ICollection<CustomTask> GetAssignedTasksToEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
