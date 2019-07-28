using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EAV.DAL.EF_Core;
using EAV.DAL.Repositories.AttributeRepository;
using EAV.DAL.Repositories.EntityRepository;
using EAV.DAL.Repositories.ValueRepository;

namespace EAV.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IAttributeRepository _attributeRepository;
        public IAttributeRepository Attributes
        {
            get
            {
                if (_attributeRepository == null)
                {
                    _attributeRepository = new AttributeRepository(_dbContext);
                }
                return _attributeRepository;
            }

        }

        private IEntityRepository _entityRepository;
        public IEntityRepository Entities
        {
            get
            {
                if (_entityRepository == null)
                {
                    _entityRepository = new EntityRepository(_dbContext);
                }
                return _entityRepository;
            }

        }

        private IValueRepository _valueRepository;
        public IValueRepository Values
        {
            get
            {
                if (_valueRepository == null)
                {
                    _valueRepository = new ValueRepository(_dbContext);
                }
                return _valueRepository;
            }

        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
