using BL.IServices;
using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ReportService : IReportService
    {
        public ICollection<Report> GetReportsByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void SubmitReport(Report report)
        {
            throw new NotImplementedException();
        }
    }
}
