using BulkCopyCSV.Domain.Interfaces.IRepositories;
using BulkCopyCSV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Infra.Data.Repository
{
    public class MoviesRepository : RepositoryBase<Movies>, IMoviesRepository
    {
        public MoviesRepository(ContextModel context) : base(context)
        {

        }
    }
}
