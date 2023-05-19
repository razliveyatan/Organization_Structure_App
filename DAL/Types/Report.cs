using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Types
{
    public class Report
    {
        public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public string ReportText { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public int ManagerId { get; set; }        
    }
}
