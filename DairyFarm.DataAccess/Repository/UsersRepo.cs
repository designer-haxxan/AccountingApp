using DairyFarm.DataAccess.Data;
using DairyFarm.DataAccess.Repository.IRepository;
using DiaryFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository
{
    public class UsersRepo : GenericRepository<Users>,IUsersRepo
    {
        private ApplicationDbContext _db;
        public UsersRepo(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public Task<IEnumerable<UsersRole>> GetUsersRole()
        {
            throw new NotImplementedException();
        }
    }
}
