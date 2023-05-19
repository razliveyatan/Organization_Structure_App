using DAL.Types;

namespace BL.IServices
{
    public interface IEmployeeService
    {
        Task<Employee> GetCustomTasksToEmployee(int employeeId);
    }
}
