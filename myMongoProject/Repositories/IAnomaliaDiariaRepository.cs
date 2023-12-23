using myMongoProject.Dto;
using myMongoProject.Models;
namespace myMongoProject.Repositories
{
    public interface IAnomaliaDiariaRepository
    {
        #region Propriedades

        public Task<IEnumerable<AnomaliaDiariaEntity>> FindAllAsync();

        public Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRotaAsync(
        string numeroViagem);

        public Task<Response> AtualizarListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity);

        public Task<AnomaliaDiariaEntity> ObterPorIdAsync(string idAnomaliaDiaria);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemAsync(string numeroViagem);

        public Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRota(string numeroViagem);

   
        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio);

        public Task<AnomaliaDiariaEntity> ObterPorId(string idAnomaliaDiaria);

        public Task<AnomaliaDiariaEntity> ObterCodigoAnomalia(int CodigoAnomalia);

        public Task<IEnumerable<AnomaliaDiariaEntity>> ObterListaPorFiltroAsync(
           AnomaliaDiariaEntity anomaliaRequest);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEIdParadaEAnomaliaTipoEnumAsync(
            string numeroViagem,
            string idParadaAnomalia,
            AnomalyTypeDocument tipo);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorListaNumeroViagemAsync(
            List<string> listaNumeroViagem,
            string idAnomaliaDiaria);

        public Task<List<AnomaliaDiariaEntity>> ObterListaAnomaliaTratativaPorNumeroViagemAsync(
            string numeroViagem);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEAnomaliaTipoEnumAsync(
            string numeroViagem,
            AnomalyTypeDocument anomaliaTipoEnum);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEListaAnomaliaTipoEnumAsync(
            string numeroViagem,
            List<AnomalyTypeDocument> listaTipos);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnumAsync(
            string idParadaAnomalia,
            List<AnomalyTypeDocument> listaTAnomaliaipoEnum);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio, AnomaliaDiariaEntity anomalia);

        public Task<Response> InserirAsync(AnomaliaDiariaEntity anomaliaDiariaEntity);

        public Task<Response> InserirListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity);

        public Task<Response> AtualizarAsync(AnomaliaDiariaEntity listaAnomaliaDiariaEntity);

        public Task<AnomaliaDiariaEntity> ResetarStatusAsync(AnomaliaDiariaEntity anomaliaDiaria);

        public Task<Response> ExcluirAsync(string idAnomaliaDiaria);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEVariasAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> anomaliasTipoEnum);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnum(string idParadaAnomalia, List<AnomalyTypeDocument> listaTAnomaliaipoEnum);

        public Task<List<AnomaliaDiariaEntity>> ObterListaPorListaGemENumeroViagem(List<string> listaNumeroViagem, string idAnomaliaDiaria);
        #endregion
    }
}
