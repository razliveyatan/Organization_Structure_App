using DAL.Types;

namespace BL.IServices
{
    public interface ITaskService
    {
        void AssignTaskToEmployee(CustomTask customTask);        
    }
}
