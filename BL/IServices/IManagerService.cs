using DAL.Types;

namespace BL.IServices
{
    public interface IManagerService
    {
        ICollection<Report> GetReportsFromSubordinates(Employee manager);
    }
}
