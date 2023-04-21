using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRHub.API.Services;
using System;
using System.Threading.Tasks;

namespace SignalRHub.API.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : Controller
    {
        private readonly IHubContext<NotificationHub> hub;
        private readonly ILogger<NotificationController> logger;
        private readonly string objBroadcastName = "TransferNotificationData";

        public NotificationController(IHubContext<NotificationHub> _hub,  ILogger<NotificationController> _logger)
        {
            hub = _hub;
            logger = _logger;
        }

        [HttpPost("PostSingle")]
        public async Task<IActionResult> Post()
        {

            await hub.Clients.All.SendAsync(objBroadcastName, string.Concat("Hub Connection Successfully Established  Your GUID Code:<br/> ",Guid.NewGuid()));
            return Ok(new { Message = "Request Complete" });
        }
    }
}
