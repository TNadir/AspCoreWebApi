using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd.Data.Domen;


namespace BackEnd.Service.Interface
{
    public interface ICategoryService
    {
        Task<List<Categories>> GetCategories();
        Task<Categories> Insert(Categories categories);
         Task<Categories> Update(Categories categories);
    }
}