using System.Threading.Tasks;
using BackEnd.BO.Repositories;
using BackEnd.Data.Domen;

namespace BackEnd.BO.Unit
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : BaseEntity;
        Task Completed();
    }
}