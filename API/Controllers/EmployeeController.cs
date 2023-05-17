using API.Models;
using BL.IServices;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase    {
        private readonly EmployeeService _employeeService;
        //private readonly LoggerService _loggerService;

        //public EmployeeController(EmployeeService employeeService, LoggerService loggerService)
        //{
        //    _employeeService = employeeService;
        //    _loggerService = loggerService;
        //}

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("get-tasks-to-employee")]
        public async Task<IActionResult> GetCustomTasksToEmployee(int employeeId = 0)
        {            
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                var reports = await _employeeService.GetCustomTasksToEmployee(employeeId);
                if (reports == null) return Ok(new ValidationViewModel(ModelState));

                return Ok(new ValidationViewModel(ModelState)
                {
                    RelatedDate = reports
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return StatusCode(500);
        }   
    }
}
