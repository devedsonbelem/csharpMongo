using MongoDB.Driver;
using myMongoProject.Dto;
using myMongoProject.Exceptions;
using myMongoProject.Models;
using myMongoProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace myMongoProject.Service
{
    public class AnomaliaDiariaService : IAnomaliaDiariaService
    {
        #region Propriedades
        private readonly IAnomaliaDiariaRepository _repository;

        public AnomaliaDiariaService(IAnomaliaDiariaRepository repository)
        {
            _repository = repository;
        }
      

        public async Task<AnomaliaDiariaEntity> ObterPorIdAsync(string idAnomaliaDiaria)
        {
            try
            {
                var anomalia = await _repository.ObterPorIdAsync(idAnomaliaDiaria);
                if (anomalia == null)
                {
                    throw new NotFoundException("Anomalia não encontrada.");
                }
                return anomalia;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter anomalia por ID.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemAsync(string numeroViagem)
        {
            try
            {
                var listaAnomalias = await _repository.ObterListaPorNumeroViagemAsync(numeroViagem);
                return listaAnomalias;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem.", ex);
            }
        }

        public async Task<Response> AtualizarAsync(AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _repository.AtualizarAsync(anomaliaDiariaEntity);
                if (resultado.Sucesso=="Sucesso")
                {
                    return resultado;
                }
                throw new UpdateFailedException("Falha ao atualizar a anomalia.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao atualizar anomalia.", ex);
            }
        }

        public async Task<Response> AtualizarListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _repository.AtualizarListaAsync(listaAnomaliaDiariaEntity);
                if (resultado.Sucesso == "Sucesso")
                {
                    return resultado;
                }
                throw new UpdateFailedException("Falha ao atualizar a lista de anomalias.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao atualizar lista de anomalias.", ex);
            }
        }

        public async Task<Response> ExcluirAsync(string idAnomaliaDiaria)
        {
            try
            {
                var resultado = await _repository.ExcluirAsync(idAnomaliaDiaria);
                if (resultado.Sucesso == "Sucesso")
                {
                    return resultado;
                }
                throw new DeleteFailedException("Falha ao excluir a anomalia.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao excluir anomalia.", ex);
            }
        }

        public async Task<Response> InserirAsync(AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _repository.InserirAsync(anomaliaDiariaEntity);
                if (resultado.Sucesso=="Sucesso")
                {
                    return resultado;
                }
                throw new InsertFailedException("Falha ao inserir a anomalia.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao inserir anomalia.", ex);
            }
        }

        public async Task<Response> InserirListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _repository.InserirListaAsync(listaAnomaliaDiariaEntity);
                if (resultado.Sucesso == "Sucesso")
                {
                    return resultado;
                }
                throw new InsertFailedException("Falha ao inserir a lista de anomalias.");
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao inserir lista de anomalias.", ex);
            }
        }

        public async Task<IEnumerable<AnomaliaDiariaEntity>> ObterListaPorFiltroAsync(AnomaliaDiariaEntity anomaliaRequest)
        {
            try
            {
                var listaAnomalias = await _repository.ObterListaPorFiltroAsync(anomaliaRequest);
                return listaAnomalias;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por filtro.", ex);
            }
        }

        public async Task<Response> InserirListaAsyncs(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                await _repository.InserirListaAsync(listaAnomaliaDiariaEntity);
                return new Response  ("Sucesso",  "Anomalias inseridas com sucesso." );
            }
            catch (Exception ex)
            {
                return new Response ("Error",  $"Erro ao inserir anomalias: {ex.Message}" );
            }
        }

        public async Task<IEnumerable<AnomaliaDiariaEntity>> ObterListaPorFiltroAsyncs(AnomaliaDiariaEntity anomaliaRequest)
        {
            try
            {
                return await _repository.ObterListaPorFiltroAsync(anomaliaRequest);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por filtro.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnumAsync(string idParadaAnomalia, List<AnomalyTypeDocument> listaTAnomaliaipoEnum)
        {
            try
            {
                return await _repository.ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnumAsync(idParadaAnomalia, listaTAnomaliaipoEnum);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por ID de parada e tipos de anomalias.", ex);
            }
        }
 
        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEAnomaliaTipoEnumAsync(string numeroViagem, AnomalyTypeDocument anomaliaTipoEnum)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemEAnomaliaTipoEnumAsync(numeroViagem, anomaliaTipoEnum);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem e tipo de anomalia.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEIdParadaEAnomaliaTipoEnumAsync(string numeroViagem, string idParadaAnomalia, AnomalyTypeDocument tipo)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemEIdParadaEAnomaliaTipoEnumAsync(numeroViagem, idParadaAnomalia, tipo);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem, ID de parada e tipo de anomalia.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(numeroViagem, anomalyTypeEnum, latitude, longitude, raio);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem, tipo de anomalia, latitude, longitude e raio.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEListaAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> listaTipos)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemEListaAnomaliaTipoEnumAsync(numeroViagem, listaTipos);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem e lista de tipos de anomalias.", ex);
            }
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEVariasAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> anomaliasTipoEnum)
        {
            try
            {
                return await _repository.ObterListaPorNumeroViagemEVariasAnomaliaTipoEnumAsync(numeroViagem, anomaliasTipoEnum);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter lista de anomalias por número de viagem e lista de tipos de anomalias.", ex);
            }
        }

        public async Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRotaAsync(string numeroViagem)
        {
            try
            {
                return await _repository.ObterMinimoPrioridadeAnomaliasRotaAsync(numeroViagem);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter a contagem mínima de prioridade de anomalias por número de viagem.", ex);
            }
        }

        public async Task<AnomaliaDiariaEntity> ObterPorIdAsynsc(string idAnomaliaDiaria)
        {
            try
            {
                return await _repository.ObterPorIdAsync(idAnomaliaDiaria);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter a anomalia por ID.", ex);
            }
        }

    //    public async Task<AnomaliaDiariaEntity> ObterPorNumeroViagemEPseudoIdMobileAsync(string numeroViagem, string pseudoIdMobileDiario)
     //   {
      //      try
        //    {
       ////         return await _repository.ObterPorNumeroViagemEPseudoIdMobileAsync(numeroViagem, pseudoIdMobileDiario);
      //      }
       //     catch (Exception ex)
        //    {
       //         throw new ServiceException("Erro ao obter a anomalia por número de viagem e pseudo ID mobile.", ex);
          //  }
       // }

        public async Task<AnomaliaDiariaEntity> ResetarStatusAsync(AnomaliaDiariaEntity anomaliaDiaria)
        {
            try
            {
               // anomaliaDiaria.StatusDiaria = AnomalyStatusTypeDocument.Pendente;
                anomaliaDiaria.UltimaData = DateTime.UtcNow;

                var result = await _repository.ResetarStatusAsync(anomaliaDiaria);
                if (result == null)
                {
                    throw new NotFoundException("Anomalia não encontrada.");
                }
                return result;
            }
            catch (NotFoundException ex2)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao resetar status da anomalia.", ex);
            }
        }

        public async Task<IEnumerable<AnomaliaDiariaEntity>> ListarTodosAsync()
        {
            return await _repository.FindAllAsync();
        }


        public async Task<AnomaliaDiariaEntity> ObterPorCodigoAnomalia(int CodigoAnomalia)
        {
            try
            {
                var anomalia = await _repository.ObterCodigoAnomalia(CodigoAnomalia);
                if (anomalia == null)
                {
                    throw new NotFoundException("Anomalia não encontrada.");
                }
                return anomalia;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Erro ao obter anomalia por ID.", ex);
            }
        }

        public Task<AnomaliaDiariaEntity> ObterCodigoAnomaliaAsync(int CodigoAnomalia)
        {
            throw new NotImplementedException();
        }


        #endregion
    }



}

