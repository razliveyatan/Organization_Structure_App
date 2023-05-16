using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Types
{
    public class CustomTask
    {
        public int CustomTaskId { get; set; }
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }

        public string CustomTaskText { get; set; } = string.Empty;
        public DateTime CustomTaskDueDate { get; set; }
        public DateTime CustomTaskAssignDate { get; set; }


        public Employee Manager { get; set; }
        public Employee Employee { get; set; }
    }
}
