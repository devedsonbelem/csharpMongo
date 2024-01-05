using myMongoProject.Dto;
using myMongoProject.Exceptions;
using myMongoProject.Models;
using myMongoProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Service
{
    public class EnvioInformacoesDiariasService : IEnvioInformacoesDiariasService
    {
        #region Propriedades
        private readonly IEnvioInformacoesDiariasRepository _repository;

        public EnvioInformacoesDiariasService(IEnvioInformacoesDiariasRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<EnvioInformacoesDiarias>> FindAllAsyncService()
        {
            return await _repository.FindAllAsync();

        }
        public async Task<Response> InserirAsyncService(EnvioInformacoesDiarias envioInformacoesDiarias)
        {
            try
            {

                var diarias = await _repository.InserirAsync(envioInformacoesDiarias);
                if (diarias == null)
                {
                    throw new NotFoundException("Envio das InformacoesDiarias não encontrada.");
                }
                return new Response("Sucesso",
                   "Envio das Informacoes Diarias inserido com sucesso.");
            }
            catch (Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        public async Task<List<EnvioInformacoesDiarias>> ObterListaPorNumeroViagemAsyncService(string  numeroViagem)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemAsync(numeroViagem);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por filtro.", ex);
            }
        }

        public async Task<EnvioInformacoesDiarias> ObterPorIdAsyncService(string IdInformacoes)
        {
            try
            {
                return await _repository.ObterPorIdAsync(IdInformacoes);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter a anomalia por ID.", ex);
            }
        }
        
        #endregion

    }
}
