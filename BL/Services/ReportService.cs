using BL.IServices;
using DAL.Repositories;
using DAL.Types;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ReportService : IReportService
    {
        private readonly ReportRepository _reportRepository;

        public ReportService(ReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public ICollection<Report> GetReportsByEmployee(Employee employee)
        {
            return _reportRepository.GetReportsByEmployee(employee);
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
                
            }
            
        }
    }
}
