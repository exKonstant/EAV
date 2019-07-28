using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAV.DAL.EF_Core;
using EAV.DAL.EntityAttributeValue;
using Microsoft.EntityFrameworkCore;

namespace EAV.DAL.Repositories.EntityRepository
{
    public class EntityRepository : Repository<Entity>, IEntityRepository
    {
        private readonly DbSet<Entity> _entities;

        public EntityRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {
            _entities = DbContext.Entities;
        }
        public override IQueryable<Entity> GetAll()
        {
            return _entities.Include(e => e.Name);
        }

        public override async Task<Entity> GetAsync(int id)
        {
            return await _entities.Include(e => e.Name).FirstOrDefaultAsync(e => e.Id == id);
        }

        public override async Task AddAsync(Entity entity)
        {
            await _entities.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var entity = new Entity() { Id = id };
            _entities.Remove(entity);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _entities.AnyAsync(e => e.Id == id);
        }
    }
}
