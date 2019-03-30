using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkCopyCSV.Domain.Repositories;
using BulkCopyCSV.Infra.Data.Context;

namespace BulkCopyCSV.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private ContextModel _context;
        private IDbSet<TEntity> _dbset;

        public BaseRepository(ContextModel context)
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            _dbset.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbset.AsEnumerable<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetByFilter(System.Linq.Expressions.Expression<Func<TEntity, bool>> lambda)
        {
            return _dbset.Where(lambda).AsEnumerable<TEntity>();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _dbset.Find(id);
        }

        public virtual void Remove(TEntity obj)
        {
            _dbset.Remove(obj);
        }

        public virtual int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

    }
}
