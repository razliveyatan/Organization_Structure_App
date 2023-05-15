using DAL;

namespace BL.IServices
{
    public interface ITaskService
    {
        bool AssignTaskToEmployee(CustomTask customTask);
        List<Task> GetTasksByEmployee(Employee employee);
    }
}
