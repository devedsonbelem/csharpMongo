using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Service
{
   public interface IHistoricoViagemService
    {
        #region Propriedades
         Task<HistoricoViagem> ObterPorIdAsyncService(string IdHistorico);
         Task<List<HistoricoViagem>> ObterListaPorNumeroViagemAsyncService(string numeroViagem);
         Task<Response> InserirAsyncService( HistoricoViagem historicoViagem);
         Task<IEnumerable<HistoricoViagem>> FindAllAsyncService();

        #endregion
    }
}
