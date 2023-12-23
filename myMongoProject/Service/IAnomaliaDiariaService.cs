using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMongoProject.Service
{
    public interface IAnomaliaDiariaService
    {
        #region Propriedades

        Task<IEnumerable<AnomaliaDiariaEntity>> ListarTodosAsync();


        Task<AnomaliaDiariaEntity> ObterPorIdAsync(string idAnomaliaDiaria);
        Task<Response> AtualizarAsync(AnomaliaDiariaEntity anomaliaDiariaEntity);
        Task<Response> AtualizarListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity);
        Task<Response> ExcluirAsync(string idAnomaliaDiaria);
        Task<Response> InserirAsync(AnomaliaDiariaEntity anomaliaDiariaEntity);
        Task<Response> InserirListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnumAsync(string idParadaAnomalia, List<AnomalyTypeDocument> listaTAnomaliaipoEnum);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEAnomaliaTipoEnumAsync(string numeroViagem, AnomalyTypeDocument anomaliaTipoEnum);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEIdParadaEAnomaliaTipoEnumAsync(string numeroViagem, string idParadaAnomalia, AnomalyTypeDocument tipo);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEListaAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> listaTipos);
        Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEVariasAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> anomaliasTipoEnum);
        Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRotaAsync(string numeroViagem);
        Task<AnomaliaDiariaEntity> ObterPorNumeroViagemEPseudoIdMobileAsync(string numeroViagem, string pseudoIdMobileDiario);
        Task<AnomaliaDiariaEntity> ResetarStatusAsync(AnomaliaDiariaEntity anomaliaDiaria);

        Task<AnomaliaDiariaEntity> ObterCodigoAnomaliaAsync(int CodigoAnomalia);
        #endregion
    }
}
