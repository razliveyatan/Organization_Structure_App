using BL.IServices;
using DAL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ManagerService:IManagerService
    {           

        public ICollection<Report> GetReportsFromSubordinates(Employee manager)
        {
            if (manager != null)
            {
                return manager.Reports;
            }
            else
            {
                throw new Exception("Manager is not valid");
            }
        }        
        
    }
}
