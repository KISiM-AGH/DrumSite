using DrumSiteApi.Entities;
using DrumSiteApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DrumSiteApi.Controllers
{
    [Route("api/tracer")]
    [ApiController]
    public class TracerController : ControllerBase
    {
        public ITracerService _tracerService;

        public TracerController(ITracerService tracerService)
        {
            _tracerService = tracerService;
        }

        [HttpGet("days")]
        public ActionResult GetDays()
        {
            var user = HttpContext.User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier);
            int userId;
            if (user != null)
            {
                userId = int.Parse(user.Value);
                var result = _tracerService.GetDays(userId);
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("days")]
        public ActionResult PostDay([FromBody]Day day)
        {
            var user = HttpContext.User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier);
            int userId;
            if (user != null)
            {
                userId = int.Parse(user.Value);
                _tracerService.InsertDay(userId, day);
                return Ok();
            }
            return NotFound();
        }
    }
}
