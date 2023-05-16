using DAL.Types;

namespace BL.IServices
{
    public interface IManagerService
    {
        Task<ICollection<Report>> GetReportsFromSubordinates(int managerId);
    }
}
