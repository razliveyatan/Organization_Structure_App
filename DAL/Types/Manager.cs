using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Types
{
    public class Manager : Employee
    {
        public ICollection<Employee> Employees { get; set; }
        public Manager()
        {
            Employees = new HashSet<Employee>();          
        }
    }
}
