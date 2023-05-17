using BL.IServices;
using DAL.Repositories;
using DAL.Types;

namespace BL.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportRepository _reportRepository;
        private readonly EmployeeRepository _employeeRepository;
        //private readonly LoggerService _loggerService;
        //public ReportService(ReportRepository reportRepository, EmployeeRepository employeeRepository, LoggerService loggerService)
        //{
        //    _reportRepository = reportRepository;
        //    _employeeRepository = employeeRepository;
        //    _loggerService = loggerService;
        //}
        public ReportService(ReportRepository reportRepository, EmployeeRepository employeeRepository)
        {
            _reportRepository = reportRepository;
            _employeeRepository = employeeRepository;            
        }

        public void SubmitReport(Report report)
        {            
            if (report == null) return;
            try
            {
                _reportRepository.AddReport(report);
                _reportRepository.SaveChange();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //_loggerService.LogError(ex.Message, nameof(ReportService), nameof(SubmitReport));
            }            
        }
    }
}
