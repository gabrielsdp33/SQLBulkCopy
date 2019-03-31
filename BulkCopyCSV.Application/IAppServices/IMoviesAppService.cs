using BulkCopyCSV.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkCopyCSV.Application.IAppServices
{
    public interface IMoviesAppService : IAppServiceBase<Movies>
    {
        void ProcessarArquivoCSV(string filePath);
    }
}
