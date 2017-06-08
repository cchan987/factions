using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.MessageHandlers;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace ProjectTracker.Controllers
{
    [Authorize]
    public class SocketMessagesController : Controller
    {
        private NotificationsMessageHandler _notificationsMessageHandler { get; set; }

        public SocketMessagesController(NotificationsMessageHandler notificationsMessageHandler)
        {
            _notificationsMessageHandler = notificationsMessageHandler;//
        }

        [HttpGet]
        public async Task SendMessage([FromQueryAttribute]string message)
        {
            string name = User.Identity.Name;
            message = name + " said: " + message;
            string json = JsonConvert.SerializeObject(new {Type = "ChatMessage", Data = message});
            await _notificationsMessageHandler.SendMessageToAllAsync(json);
        }
    }
}