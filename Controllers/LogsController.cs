using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTimings;
using System.Threading;
using System.Threading.Tasks;

namespace Cherrylog.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            //Do some query;

            using (Operation.Time("Do some db query"))
            {
                Thread.Sleep(500);
                _logger.LogInformation("==========>>>>>>>>DB Query done");
            }

            return Ok(await Task.FromResult("Result ready."));
        }


    }
}
