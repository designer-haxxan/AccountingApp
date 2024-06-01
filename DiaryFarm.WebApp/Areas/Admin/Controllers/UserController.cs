using DairyFarm.DataAccess.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DiaryFarm.WebApp.Areas.Admin.Controllers
{
    [AuthenticationFilter]
    [Area("Admin")]
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}
