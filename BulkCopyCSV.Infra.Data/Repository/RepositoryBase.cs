using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BulkCopyCSV.Domain.Repositories;
using BulkCopyCSV.Infra.Data.Context;

namespace BulkCopyCSV.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private ContextModel _context;
        private IDbSet<TEntity> _dbset;

        public RepositoryBase(ContextModel context)
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

        public virtual void BulkCopy<T>(string filePath) where T: class, new()
        { 
            T obj = new T();
            
            var connString = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0; Data Source={0};Extended Properties=""Text;HDR=Yes;FMT=Delimited""", Path.GetDirectoryName(filePath));
            string query = string.Format("Select * from [{0}]", Path.GetFileName(filePath));

            
            //var lines = File.ReadAllLines(filePath);

            using (var conn = new OleDbConnection(connString))
            {
                conn.Open();

                OleDbCommand command = new OleDbCommand(query, conn);
                OleDbDataReader reader = command.ExecuteReader();


                var destConnection = (SqlConnection)_context.Database.Connection;

                try
                {
                    SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnection, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.Default, null);
                    var count = 0;
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        MemberInfo property = obj.GetType().GetProperty(prop.Name);
                        var dd = property.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
                        if (!String.IsNullOrEmpty(dd.Name))
                        {
                            bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(count, prop.Name));
                            count++;
                        }
                    }

                    bulkCopy.DestinationTableName = "Movies";
                    bulkCopy.BulkCopyTimeout = 2000;
                    bulkCopy.BatchSize = 1000;


                    try
                    {
                        destConnection.Open();
                        bulkCopy.WriteToServer(reader);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        destConnection.Close();
                        reader.Close();



                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }


    }
}
