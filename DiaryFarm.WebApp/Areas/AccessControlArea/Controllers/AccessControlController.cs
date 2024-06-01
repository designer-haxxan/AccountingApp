using DairyFarm.DataAccess.Repository.IRepository;
using DiaryFarm.Models;
using DiaryFarm.Models.ViewModels.AccessControl;
using Microsoft.AspNetCore.Mvc;

namespace DiaryFarm.WebApp.Areas.AccessControlArea.Controllers
{
    [Area("AccessControlArea")]
    public class AccessControlController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccessControlController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            ResponseModel result = await _unitOfWork.Authentication.Authenticate(model);

            if (result.isSuccess)
            {
                return Ok(new { success = true, message = result.Message });
            }
            else
            {
                return Ok(new { success = false, message = result.Message });
            }
        }



    }
}
