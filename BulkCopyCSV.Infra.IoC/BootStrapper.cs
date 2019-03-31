using BulkCopyCSV.Application.AppServices;
using BulkCopyCSV.Application.IAppServices;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkCopyCSV.Domain.Services;
using BulkCopyCSV.Domain.Interfaces.IServices;
using BulkCopyCSV.Domain.Interfaces.IRepositories;
using BulkCopyCSV.Infra.Data.Repository;
using BulkCopyCSV.Infra.Data.Context;

namespace BulkCopyCSV.Infra.IoC
{
    public class BootStrapper
    {
        public static Container container;

        public static void Start()
        {
            container = new Container();

            container.Register<IMoviesAppService, MoviesAppService>();
            container.Register<IMoviesService, MoviesService>();
            container.Register<IMoviesRepository, MoviesRepository>();

            
        }
    }
}
