using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Services;
using System.Security.Claims;
using System;
using ProjectTracker.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using ProjectTracker.MessageHandlers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectTracker.Controllers
{
    [Authorize]
    public class ProjectLobbyController : Controller
    {
        private IProjectData _ProjectData;
        private NotificationsMessageHandler _WebSocket;

        public ProjectLobbyController(IProjectData projectData, NotificationsMessageHandler notificationsMessageHandler)
        {
            _WebSocket = notificationsMessageHandler;
            _ProjectData = projectData;
        }

        public IActionResult Index()
        {
            
            ViewBag.title = User.Identity.Name;
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); Get userId             
            //return View({inProgress: .... , acceptingParticipants: ....});
            return View();
        }

        [HttpGet]
        public async Task InitialMessageAsync()
        {
            await _WebSocket.SendMessageToAllAsync("Welcome to the page");

            //Send Project that user is participating in
            string ParticipatingInJson = _ProjectData.ParticipatingIn(User.Identity.Name).ToJSON("ParticipatingIn");
            await _WebSocket.SendMessageToAllAsync(ParticipatingInJson);

            //Send List of projects accepting participants
            List<Project> ListOfAccepting = _ProjectData.GetAcceptingParticipants();
            foreach (var i in ListOfAccepting)
            {
                string AcceptingJson = i.ToJSON("AcceptingParticipants");
                await _WebSocket.SendMessageToAllAsync(AcceptingJson);
            }

            //Send list of projects in progress
            List<Project> ListOfProgress = _ProjectData.GetInProgress();
            foreach (var i in ListOfProgress)
            {
                string AcceptingJson = i.ToJSON("InProgress");
                await _WebSocket.SendMessageToAllAsync(AcceptingJson);
            }
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult CreateProject()
        {

        }
        */
        public IActionResult JoinProject(int ProjId)
        {
            Project toBeJoined = _ProjectData.Get(ProjId);
            if (toBeJoined == null)
            {
                return View("ErrorNoProject");
            }

            else if (!toBeJoined.isAcceptingParticipants)
            {
                UserParticipation inProject = _ProjectData.GetParticipation(User.Identity.Name);
                if (inProject.ProjectId == ProjId)
                {
                    return RedirectToAction("Join", "ProjectController", new {Id = ProjId});
                }
            }
            else if (toBeJoined.isAcceptingParticipants)
            {
                return RedirectToAction("Join", "ProjectController", new { Id = ProjId });
            }
            return View("ErrorNoAccess");
        }
            
    }
}
