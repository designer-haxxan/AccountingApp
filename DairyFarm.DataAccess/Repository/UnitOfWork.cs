using DairyFarm.DataAccess.Data;
using DairyFarm.DataAccess.Repository.IRepository;
using DiaryFarm.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepo Users { get; private set; }
        public IAuthentication Authentication { get; private set; }
        public IGenericRepository<UsersRole> Roles { get; private set; }
        public UnitOfWork(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            Users = new UsersRepo(db);
            Authentication = new Authentication(Users, httpContextAccessor);
            Roles=new GenericRepository<UsersRole>(db);
        }
    }
}
