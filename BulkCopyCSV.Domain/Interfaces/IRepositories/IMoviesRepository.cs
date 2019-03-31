using BulkCopyCSV.Domain.Repositories;
using BulkCopyCSV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Domain.Interfaces.IRepositories
{
    public interface IMoviesRepository : IRepositoryBase<Movies>
    {
    }
}
