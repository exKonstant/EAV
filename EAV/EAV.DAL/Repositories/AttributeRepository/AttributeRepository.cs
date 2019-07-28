using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EAV.DAL.EF_Core;
using EAV.DAL.EntityAttributeValue;
using Microsoft.EntityFrameworkCore;

namespace EAV.DAL.Repositories.AttributeRepository
{
    public class AttributeRepository : Repository<Attributes>, IAttributeRepository
    {
        private readonly DbSet<Attributes> _attributes;

        public AttributeRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {
            _attributes = DbContext.Attributes;
        }
        public override IQueryable<Attributes> GetAll()
        {
            return _attributes.Include(a => a.Name);
        }

        public override async Task<Attributes> GetAsync(int id)
        {
            return await _attributes.Include(a => a.Name).FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task AddAsync(Attributes entity)
        {
            await _attributes.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var attribute = new Attributes { Id = id };
            _attributes.Remove(attribute);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _attributes.AnyAsync(a => a.Id == id);
        }
    }
}
