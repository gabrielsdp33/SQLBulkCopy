using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Domain.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetByFilter(System.Linq.Expressions.Expression<Func<TEntity, bool>> lambda);
        int Save();
        void BulkCopy<T>(string filePath) where T : class, new();
    }
}
