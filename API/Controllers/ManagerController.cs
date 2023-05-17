using API.Models;
using BL.Services;
using DAL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly ManagerService _managerService;

        public ManagerController(ManagerService managerService)
        {
            _managerService = managerService;
        }        

        [HttpGet("get-reports-from-subordinates")]
        public async Task<IActionResult> GetReportsFromSubordinates(int managerId = 0)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                var reports = await _managerService.GetReportsFromSubordinates(managerId);
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
        }

        [HttpPost("assign-task-to-employee")]
        public IActionResult AssignTaskToEmployee(CustomTask customTask)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                _managerService.AssignTaskToEmployee(customTask);
                return Ok(new ValidationViewModel(ModelState));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
