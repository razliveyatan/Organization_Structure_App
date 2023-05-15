using BL.IServices;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class CustomTaskService : ITaskService
    {
        public bool AssignTaskToEmployee(CustomTask customTask)
        {
            throw new NotImplementedException();
        }

        public List<Task> GetTasksByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
