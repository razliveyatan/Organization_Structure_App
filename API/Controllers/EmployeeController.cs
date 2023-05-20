using API.Models;
using BL.IServices;
using BL.Services;
using DAL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
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

        [HttpGet("get-employee-details")]
        public async Task<IActionResult> GetEmployeeDetails(int employeeId = 0)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                var employee = await _employeeService.GetEmployeeDetails(employeeId);
                if (employee == null) return Ok(new ValidationViewModel(ModelState));
                return Ok(new ValidationViewModel(ModelState)
                {
                    RelatedData = employee
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpGet("get-tasks-to-employee")]
        //public async Task<IActionResult> GetCustomTasksToEmployee(int employeeId = 0)
        //{            
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return Ok(new ValidationViewModel(ModelState));
        //        }
        //        var reports = await _employeeService.GetCustomTasksToEmployee(employeeId);
        //        if (reports == null) return Ok(new ValidationViewModel(ModelState));

        //        return Ok(new ValidationViewModel(ModelState)
        //        {
        //            RelatedDate = reports
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [HttpPost("submit-report")]
        public IActionResult SubmitReport(Report report)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                _employeeService.SubmitReport(report);
                return Ok(new ValidationViewModel(ModelState));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();
                if (employees == null) return Ok(new ValidationViewModel(ModelState));
                return Ok(new ValidationViewModel(ModelState)
                {
                    RelatedData = employees
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

    }
}
