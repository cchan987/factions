using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProjectTracker.Services;

namespace ProjectTracker.Controllers
{
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
                ViewBag.projects = _ProjectData.Get(1);
                //Get in progress projects
                //Get accepting participants projects
                //return View({inProgress: .... , acceptingParticipants: ....});
            }
            return View();
        }
    }
}
