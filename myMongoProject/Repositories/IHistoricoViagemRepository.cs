using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Repositories
{
    public interface IHistoricoViagemRepository
    {
        #region Propriedades
        public Task<HistoricoViagem> ObterPorIdAsync(string IdHistorico);
        public   Task<List<HistoricoViagem>> ObterListaPorNumeroViagemAsync(string numeroViagem);
        public  Task<Response> InserirAsync( HistoricoViagem historicoViagem);
        public   Task<IEnumerable<HistoricoViagem>> FindAllAsync();
        #endregion
    }
}
