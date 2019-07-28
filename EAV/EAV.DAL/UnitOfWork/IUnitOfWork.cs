using System.Threading.Tasks;
using EAV.DAL.Repositories.AttributeRepository;
using EAV.DAL.Repositories.EntityRepository;
using EAV.DAL.Repositories.ValueRepository;

namespace EAV.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAttributeRepository Attributes { get; }
        IEntityRepository Entities { get; }
        IValueRepository Values { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}