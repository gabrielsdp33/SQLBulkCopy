using BulkCopyCSV.Domain.Interfaces.IRepositories;
using BulkCopyCSV.Domain.Interfaces.IServices;
using BulkCopyCSV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Domain.Services
{
    public class MoviesService : ServiceBase<Movies>, IMoviesService
    {
        private IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository) : base(moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
    }
}
