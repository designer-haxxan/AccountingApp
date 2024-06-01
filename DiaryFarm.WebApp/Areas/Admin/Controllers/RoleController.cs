using DairyFarm.DataAccess.Filters;
using DairyFarm.DataAccess.Repository.IRepository;
using DiaryFarm.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryFarm.WebApp.Areas.Admin.Controllers
{
    [AuthenticationFilter]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Roles()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ViewAllRoles()
        {
            var result = await _unitOfWork.Roles.GetAll();
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> SaveRole([FromBody] UsersRole model)
        {
            ResponseModel result = await _unitOfWork.Roles.Add(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole([FromBody] UsersRole model)
        {
            ResponseModel result = await _unitOfWork.Roles.Update(model);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole([FromBody] long id)
        {
            ResponseModel result = await _unitOfWork.Roles.Delete(id);
            return Ok(result);
        }



    }
}
