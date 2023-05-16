using DAL.Types;
using Microsoft.EntityFrameworkCore;
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
        public async Task<Report> GetReportById(int id)
        {
            return await dbContext.Reports.FirstOrDefaultAsync(x => x.ReportId == id);
        }       

        public async Task<Report> EditReport(Report report)
        {
            var reportToEdit = await dbContext.Reports.FirstOrDefaultAsync(x => x.ReportId == report.ReportId);
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
