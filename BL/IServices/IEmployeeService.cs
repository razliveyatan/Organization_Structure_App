using DAL;

namespace BL.IServices
{
    public interface IEmployeeService
    {
        List<Task> GetAssignedTasksToEmployee(Employee employee);
    }
}
