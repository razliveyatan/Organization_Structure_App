using BL.IServices;
using DAL.Types;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BL.Services
{
    public class CustomTaskService : ITaskService
    {
        public void AssignTaskToEmployee(CustomTask customTask)
        {
            
        }

        public ICollection<CustomTask> GetTasksByEmployee(Employee employee)
        {
         
        }
    }
}
