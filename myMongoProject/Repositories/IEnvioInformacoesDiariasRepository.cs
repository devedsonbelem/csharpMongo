using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Repositories
{
    public interface IEnvioInformacoesDiariasRepository
    {
        #region Propriedades
        public Task<IEnumerable<EnvioInformacoesDiarias>> FindAllAsync();

        public Task<List<EnvioInformacoesDiarias >> ObterListaPorNumeroViagemAsync(string  numeroViagem);

        public Task<Response> InserirAsync(EnvioInformacoesDiarias  envioInformacoesDiarias);

        public  Task<EnvioInformacoesDiarias> ObterPorIdAsync(string IdInformacoes);

        #endregion
    }
}
