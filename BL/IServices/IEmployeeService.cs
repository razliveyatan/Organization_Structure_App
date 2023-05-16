using DAL.Types;

namespace BL.IServices
{
    public interface IEmployeeService
    {
        ICollection<CustomTask> GetAssignedTasksToEmployee(Employee employee);
    }
}
