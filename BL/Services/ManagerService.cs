using BL.IServices;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ManagerService:IManagerService
    {           

        public List<Report> GetReportsFromSubordinates(Employee manager)
        {
            throw new NotImplementedException();
        }        
        
    }
}
