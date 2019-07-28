using System.Linq;
using System.Threading.Tasks;
using EAV.DAL.EntityAttributeValue.Base;

namespace EAV.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetAsync(int id);
        IQueryable<TEntity> GetAll();
        Task AddAsync(TEntity entity);
        Task<bool> ContainsEntityWithId(int id);
        void Delete(int id);
    }
}