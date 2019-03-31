using BulkCopyCSV.Application.IAppServices;
using BulkCopyCSV.Domain.Interfaces.IServices;
using BulkCopyCSV.Domain.Services;
using BulkCopyCSV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Application.AppServices
{
    public class MoviesAppService : AppServiceBase<Movies>, IMoviesAppService
    {
        IMoviesService _moviesService;

        public MoviesAppService(IMoviesService moviesService) : base(moviesService)
        {
            _moviesService = moviesService;
        }

        public void ProcessarArquivoCSV(string filePath)
        {
            _moviesService.BulkCopy(filePath);
        }

    }
}
