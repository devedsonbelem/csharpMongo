using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Service
{
    public interface IEnvioInformacoesDiariasService
    {
        public Task<IEnumerable<EnvioInformacoesDiarias>> FindAllAsyncService();

        public Task<Response> InserirAsyncService(EnvioInformacoesDiarias envioInformacoesDiarias);

        public  Task<List<EnvioInformacoesDiarias>> ObterListaPorNumeroViagemAsyncService(string numeroViagem);

        public Task<EnvioInformacoesDiarias> ObterPorIdAsyncService(string IdInformacoes);
    }
}
