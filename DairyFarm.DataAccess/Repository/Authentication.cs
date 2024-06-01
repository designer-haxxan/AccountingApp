using DairyFarm.DataAccess.Repository.IRepository;
using DiaryFarm.Models;
using DiaryFarm.Models.ViewModels.AccessControl;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository
{
    public class Authentication : IAuthentication
    {
        private readonly IGenericRepository<Users> _users;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Authentication(IGenericRepository<Users> users, IHttpContextAccessor httpContextAccessor)
        {
            _users = users;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseModel> Authenticate(LoginViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.username) || string.IsNullOrEmpty(model.password))
                {
                    return new ResponseModel()
                    {
                        isSuccess = false,
                        Message = "Username and Password Are Not Null"
                    };
                }

                var data = await _users.GetBy(x => x.username == model.username && x.password == model.password);
                if (data != null)
                {
                    if (!data.Active)
                    {
                        return new ResponseModel()
                        {
                            isSuccess = false,
                            Message = "Sorry You are No Longer User of this Web App"
                        };
                    }
                    _httpContextAccessor.HttpContext.Session.SetString("Username", data.username);
                    _httpContextAccessor.HttpContext.Session.SetString("UserId", data.Id.ToString());
                    _httpContextAccessor.HttpContext.Session.SetString("UserRoleId", data.RoleId.ToString());
                    return new ResponseModel()
                    {
                        isSuccess = true,
                        Message = "Authentication successful"
                    };
                }
                else
                {
                    return new ResponseModel()
                    {
                        isSuccess = false,
                        Message = "Invalid username or password"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    isSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
