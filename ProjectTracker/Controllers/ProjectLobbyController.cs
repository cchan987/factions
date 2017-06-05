using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Services;
using System.Security.Claims;
using System;
using ProjectTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjectTracker.Controllers
{
    [Authorize]
    public class ProjectLobbyController : Controller
    {
        private IProjectData _ProjectData;

        public ProjectLobbyController(IProjectData projectData)
        {
            _ProjectData = projectData;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                ViewBag.title = User.Identity.Name;
                ViewBag.inProgress = _ProjectData.GetInProgress();
                ViewBag.AcceptingParticipants = _ProjectData.GetAcceptingParticipants();
                ViewBag.ParticipatingIn = _ProjectData.ParticipatingIn(User.Identity.Name);
                //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); Get userId             
                //return View({inProgress: .... , acceptingParticipants: ....});
            }
            return View();
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
