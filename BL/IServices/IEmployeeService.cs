using DAL.Types;

namespace BL.IServices
{
    public interface IEmployeeService
    {
        Task<ICollection<CustomTask>> GetCustomTasksToEmployee(int employeeId);
    }
}
