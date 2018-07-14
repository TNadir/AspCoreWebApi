using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.Data.Domen;
namespace BackEnd.Service.Interface
{
    public interface IUser
    {
        Task<Users> Insert(Users user);
        Task<Users> Get(int id);
        Task<List<Users>> GetAll();
        Task<List<Users>> FindBy(Expression<Func<Users, bool>> predicate);
    }
}