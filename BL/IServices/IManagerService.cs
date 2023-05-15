using DAL;

namespace BL.IServices
{
    public interface IManagerService
    {
        List<Report> GetReportsFromSubordinates(Employee manager);
    }
}
