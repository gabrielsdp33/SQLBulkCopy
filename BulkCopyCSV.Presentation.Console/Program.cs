using BulkCopyCSV.Application.IAppServices;
using BulkCopyCSV.Infra.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BulkCopyCSV.Presentation.Console
{
    class Program
    {
        static IMoviesAppService _moviesAppService;
        
        static void Main(string[] args)
        {
            string filePath = @"C:\users\Gabriel\Documents\Movies.csv";

            BootStrapper.Start();
            _moviesAppService = BootStrapper.container.GetInstance<IMoviesAppService>();
            _moviesAppService.ProcessarArquivoCSV(filePath);

        
        }

    }
    
}

