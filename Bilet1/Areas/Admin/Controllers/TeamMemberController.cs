using Microsoft.AspNetCore.Mvc;

namespace Bilet1.Areas.Admin.Controllers
{
    public class TeamMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
