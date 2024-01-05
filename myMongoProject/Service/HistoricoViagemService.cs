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
   public class HistoricoViagemService : IHistoricoViagemService
    {
        #region Propriedades

        private readonly IHistoricoViagemRepository _repository;

        public HistoricoViagemService(IHistoricoViagemRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<HistoricoViagem>> FindAllAsyncService()
        {
            return await _repository.FindAllAsync();

        }
        public async Task<Response> InserirAsyncService( HistoricoViagem historicoViagem)
        {
            try
            {
                
                var historico = await _repository.InserirAsync(historicoViagem);
                if (historico == null)
                {
                    throw new NotFoundException("Historico não encontrada.");
                }
                return new Response("Sucesso",
                   "Historico Viagem inserido com sucesso.");
            }
            catch(Exception ex)
            {
                throw new NotFoundException(ex.Message);
            }
        }

        public async Task<List<HistoricoViagem>> ObterListaPorNumeroViagemAsyncService(string numeroViagem)
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

        public async Task<HistoricoViagem> ObterPorIdAsyncService(string IdHistorico)
        {
            try
            {
                return await _repository.ObterPorIdAsync(IdHistorico);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter a anomalia por ID.", ex);
            }
        }
        public async Task<Response> InserirAsync(HistoricoViagem historicoViagem)
        {
            try
            {
                var resultado = await _repository.InserirAsync(historicoViagem);
                if (resultado.Sucesso == "Sucesso")
                {
                    return resultado;
                }
                throw new InsertFailedException("Falha ao inserir a historicoViagem.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao inserir historicoViagem.", ex);
            }
        }

       

        #endregion
    }
}
