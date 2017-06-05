using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectTracker.MessageHandlers;

namespace ProjectTracker.Controllers
{
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
            await _notificationsMessageHandler.SendMessageToAllAsync(name + " said: " + message);
        }
    }
}