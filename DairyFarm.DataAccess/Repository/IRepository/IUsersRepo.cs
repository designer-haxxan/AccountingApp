using DiaryFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository.IRepository
{
    public interface IUsersRepo : IGenericRepository<Users>
    {
        Task<IEnumerable<UsersRole>> GetUsersRole();
    }
}
