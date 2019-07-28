using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAV.DAL.EF_Core;
using EAV.DAL.EntityAttributeValue.Base;

namespace EAV.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext DbContext;
        protected Repository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public abstract Task<TEntity> GetAsync(int id);
        public abstract IQueryable<TEntity> GetAll();
        public abstract Task AddAsync(TEntity entity);
        public abstract Task<bool> ContainsEntityWithId(int id);
        public abstract void Delete(int id);
    }
}
