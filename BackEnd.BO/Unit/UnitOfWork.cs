using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.BO.Repositories;
using BackEnd.Data.Domen;

namespace BackEnd.BO.Unit
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly ApplicationContext context;

        private bool disposed;
        public UnitOfWork(ApplicationContext _context)
        {
            this.context = _context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Completed()
        {
           await context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            IRepository<T> repository = new Repository<T>(this.context);
            repositories.Add(typeof(T), repository);
            return repository;
        }


    }
}