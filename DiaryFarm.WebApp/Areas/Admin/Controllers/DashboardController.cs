using Microsoft.AspNetCore.Mvc;
using DairyFarm.DataAccess.Filters;

namespace DiaryFarm.WebApp.Areas.Admin.Controllers
{
    [AuthenticationFilter]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Analytics()
        {
            return View();
        }
    }
}
