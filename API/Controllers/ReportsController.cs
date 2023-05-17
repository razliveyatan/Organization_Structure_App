using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("submit-report")]
        public IActionResult SubmitReport(Report report)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new ValidationViewModel(ModelState));
                }
                _reportService.SubmitReport(report);
                return Ok(new ValidationViewModel(ModelState));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
