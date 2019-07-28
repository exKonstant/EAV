using EAV.DAL.EF_Core;
using EAV.DAL.EntityAttributeValue;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EAV.DAL.Repositories.ValueRepository
{
    public class ValueRepository : Repository<Value>, IValueRepository
    {
        private readonly DbSet<Value> _values;

        public ValueRepository(AppDbContext applicationDbContext) : base(applicationDbContext)
        {
            _values = DbContext.Values;
        }
        public override IQueryable<Value> GetAll()
        {
            return _values
                .Include(v => v.Attribute)
                .Include(v => v.Entity);
        }

        public override async Task<Value> GetAsync(int id)
        {
            return await _values
                .Include(v => v.Attribute)
                .Include(v => v.Entity)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task AddAsync(Value entity)
        {
            await _values.AddAsync(entity);
        }

        public override void Delete(int id)
        {
            var value = new Value() { Id = id };
            _values.Remove(value);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await _values.AnyAsync(a => a.Id == id);
        }
    }
}
