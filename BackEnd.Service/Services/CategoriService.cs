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
    public class CategoriService : ICategoryService
    {
        private readonly IRepository<Categories> repo;
        private string errorMessage = string.Empty;

        public CategoriService(IRepository<Categories> _repo)
        {
            this.repo = _repo;
        }

        public Task Delete(Categories categories)
        {
          return  this.repo.Delete(categories);
        }

        public Task<List<Categories>> GetCategories()
        {
            return this.repo.GetAll();
        }

        public Task<Categories> Insert(Categories categories)
        {
            try
            {
                return this.repo.Insert(categories);
            }
            catch (Exception ex)
            {
                this.errorMessage = ex.Message;
                return null;
            }

        }

        public Task<Categories> Update(Categories categories)
        {
            try
            {
                return this.repo.Update(categories);
            }
            catch (Exception ex)
            {
                this.errorMessage = ex.Message;
                return null;
            }
        }



    }
}