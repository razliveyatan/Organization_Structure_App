using DAL;

namespace BL.IServices;
public interface IReportService
{
    bool SubmitReport(Report report);
    List<Report> GetReportsByEmployee(Employee employee);
}
