using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.BO.Repositories;
using BackEnd.BO.Unit;
using BackEnd.Data.Domen;
using BackEnd.Service.Interface;

namespace BackEnd.Service.Services
{
    public class UserService : IUser
    {
        private readonly IRepository<Users> repo;

        private string errorMessage = string.Empty;
        public UserService(IRepository<Users> _repo)
        {
            this.repo = _repo;
        }

        public Task<Users> Get(int id)
        {
            return this.repo.GetById(id);
        }

        public Task<List<Users>> FindBy(Expression<Func<Users, bool>> predicate)
        {
            return this.repo.FindBy(predicate);
        }

        public Task<List<Users>> GetAll()
        {
            return this.repo.GetAllAsync();
        }

        public Task<Users> Insert(Users user)
        {
            try
            {
                var usr = this.repo.Insert(user);
                // this.unitOfWork.Completed();
                return usr;
            }
            catch (Exception ex)
            {
                this.errorMessage = ex.Message;
                return null;

            }

        }
    }
}