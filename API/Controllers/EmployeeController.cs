using BL.Services;
using DAL.Types
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase    {
        private readonly EmployeeService _employeeService;
        private readonly LoggerService _loggerService;

        public EmployeeController(EmployeeService employeeService, LoggerService loggerService)
        {
            _employeeService = employeeService;
            _loggerService = loggerService;
        }

        public async Task<ICollection<Report>> GetReportsByEmployee(Employee employee)
        {
            if (employee == null) return null;
            try
            {
                var reports = await _employeeService.GetReportsByEmployee(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }   
    }
}
