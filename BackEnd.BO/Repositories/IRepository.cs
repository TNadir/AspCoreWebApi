using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.Data.Domen;

namespace BackEnd.BO.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {

        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllAsync();
        Task Update(T entity);
        Task Delete(T entity);
    }
}