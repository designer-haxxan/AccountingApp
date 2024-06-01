using DiaryFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IUsersRepo Users { get;}
        public IAuthentication Authentication { get;}
        public IGenericRepository<UsersRole> Roles { get;}
    }
}
