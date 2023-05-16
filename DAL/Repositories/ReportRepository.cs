using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReportRepository
    {
        private readonly Org_Structure_DbContext dbContext;
        public ReportRepository(Org_Structure_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddReport(Report report)
        {
            dbContext.Reports.Add(report);
        }   
        public void RemoveReport(Report report)
        {
            dbContext.Reports.Remove(report);
        }
        public Report GetReportById(int id)
        {
            return dbContext.Reports.FirstOrDefault(x => x.ReportId == id);
        }
        public ICollection<Report> GetReportsByEmployee(Employee employee)
        {
            return dbContext.Reports.Where(x => x.EmployeeId == employee.EmployeeId).ToList();
        }

        public Report EditReport(Report report)
        {
            var reportToEdit = dbContext.Reports.FirstOrDefault(x => x.ReportId == report.ReportId);
            reportToEdit.ReportText = report.ReportText;
            reportToEdit.ReportDate = report.ReportDate;
            return reportToEdit;
        }        

        public void SaveChange()
        {
            dbContext.SaveChanges();
        }
    }
}
