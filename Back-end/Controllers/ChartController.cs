using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace signalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {
        private IHubContext<DataHub> _hub;

        public ChartController(IHubContext<DataHub> hub)
        {
            _hub = hub;
        }

        [HttpGet("send/graph1")]
        public IActionResult GetTest()
        {
            Random rd = new Random();
            var result = _hub.Clients.All.SendAsync("chartStation1",rd.Next(0,200));
            return Ok(new { Status = "Send To Graph 1 Completed" });
        }

        [HttpGet("send/graph2")]
        public IActionResult GetTest2()
        {
            Random rd = new Random();
            var result = _hub.Clients.All.SendAsync("chartStatus2", rd.Next(300, 500));
            return Ok(new { Status = "Send To Graph 2 Completed" });
        }
    }
}