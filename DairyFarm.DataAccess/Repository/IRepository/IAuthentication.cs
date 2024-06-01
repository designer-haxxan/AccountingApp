using DiaryFarm.Models;
using DiaryFarm.Models.ViewModels.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository.IRepository
{
    public interface IAuthentication
    {
        Task<ResponseModel> Authenticate(LoginViewModel model);
    }
}
