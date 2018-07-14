using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BackEnd.Data.Domen;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BO.Repositories
{
    public class Repository<T> :
             IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;
        public Repository(ApplicationContext _context)
        {
            this.context = _context;

        }
        public async Task Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");

            }

            this.context.Entry(entity).State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }

        public async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await this.Entities.Where(predicate).ToListAsync();
        }


        public async Task<T> GetById(int id)
        {
            return await this.Entities.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.Entities.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.context.Entry(entity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();

        }

        public async Task<List<T>> GetAll()
        {
            return await this.Entities.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this.Entities.ToListAsync();
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }


    }
}