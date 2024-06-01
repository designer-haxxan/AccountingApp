using DiaryFarm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DairyFarm.DataAccess.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByList(Expression<Func<T, bool>> filter);
        Task<T> GetBy(Expression<Func<T, bool>> filter);
        Task<T> GetById(object id);
        Task<ResponseModel> Remove(T entity);
        Task<ResponseModel> Delete(Object Id);
        Task<ResponseModel> RemoveRange(IEnumerable<T> entity);
        Task<int> Count(Expression<Func<T, bool>> filter);
        Task<bool> Exists(Expression<Func<T, bool>> filter);
        Task<ResponseModel> UpdateRange(IEnumerable<T> entities);
        Task<ResponseModel> Update(T entity);
        Task<ResponseModel> Add(T entity);
        Task<ResponseModel> AddRange(IEnumerable<T> entities);
    }
}
