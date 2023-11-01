using Microsoft.AspNetCore.Mvc;

namespace smartwyreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthzController : Controller
    {
        [HttpGet("readiness")]
        public IActionResult Readiness()
        {           
            
            if (isApiReadinessOk())
            {
                return Ok(new { status = "ok" });
            }
            else
            {
                return StatusCode(503, new { status = "API is not ready" });
            }
        }

        [HttpGet("liveness")]
        public IActionResult Liveness()
        {
            // Check the liveness condition here
            if (IsApiHealthy())
            {
                return Ok(new { status = "healthy" });
            }
            else
            {
                return StatusCode(503, new { status = "unhealthy" });
            }
        }

        private bool IsApiHealthy()
        {            
            // Here's a simple check to ensure the API is always considered healthy:
            return true;
        }

        private bool isApiReadinessOk()
        {
            // if we have defendence component of API we will check them here and change it based on it.
            return true;
        }

    }
}
