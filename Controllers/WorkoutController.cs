using Microsoft.AspNetCore.Mvc;

namespace LiftingApp.Controllers
{
    public class WorkoutController : Controller
    {
        public IActionResult Index()
        {
            return Content("Workout page working as expectted");
        }
    }
}