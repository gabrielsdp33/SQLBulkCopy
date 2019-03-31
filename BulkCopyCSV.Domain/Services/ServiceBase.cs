using BulkCopyCSV.Domain.Interfaces.IServices;
using BulkCopyCSV.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, new()
    {
        protected IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public virtual void Add(TEntity obj)
        {
            _repositoryBase.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public virtual IEnumerable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> lambda)
        {
            return _repositoryBase.GetByFilter(lambda);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _repositoryBase.GetById(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _repositoryBase.Remove(obj);
        }

        public virtual int Save()
        {
            return _repositoryBase.Save();
        }

        public virtual void Update(TEntity obj)
        {
            _repositoryBase.Update(obj);
        }

        public void BulkCopy(string filePath)
        {
            _repositoryBase.BulkCopy<TEntity>(filePath);
        }
    }
}
