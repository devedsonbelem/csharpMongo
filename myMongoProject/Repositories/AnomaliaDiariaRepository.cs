using MongoDB.Driver;
using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Linq.Expressions;

namespace myMongoProject.Repositories
{
    public class AnomaliaDiariaRepository : IAnomaliaDiariaRepository
    {
        #region Propriedades
        private readonly string _connectionString = "mongodb://localhost:27017";
        private readonly string _databaseName = "BancoUm";
        string Sucesso = "sucesso";
        private object projection;


        private readonly IMongoCollection<AnomaliaDiariaEntity> _collection;

        public AnomaliaDiariaRepository()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<AnomaliaDiariaEntity>("anomaliadiarias");
        }

        public async Task<AnomaliaDiariaEntity> ObterPorIdAsync(string idAnomaliaDiaria)
        {
            return await _collection.Find(a => a.Id == idAnomaliaDiaria).FirstOrDefaultAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemAsync(string numeroViagem)
        {
            return await _collection.Find(a => a.Viagem == numeroViagem).ToListAsync();
        }


        public async Task<Response> AtualizarListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                var bulkWriteModels = new List<WriteModel<AnomaliaDiariaEntity>>();

                foreach (var anomalia in listaAnomaliaDiariaEntity)
                {
                    var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(x => x.Id, anomalia.Id);
                    var update = Builders<AnomaliaDiariaEntity>.Update
                        .Set(x => x.Viagem, anomalia.Viagem)
                        .Set(x => x.PrioridadeAnomalia, anomalia.PrioridadeAnomalia)
                        .Set(x => x.StatusDiaria, anomalia.StatusDiaria)
                       .CurrentDate(x => x.UltimaData);

                    var updateModel = new UpdateOneModel<AnomaliaDiariaEntity>(filter, update);
                    bulkWriteModels.Add(updateModel);
                }

                if (bulkWriteModels.Any())
                {
                    var bulkWriteResult = await _collection.BulkWriteAsync(bulkWriteModels);
                    if (bulkWriteResult.IsAcknowledged)
                    {
                        return new Response("Sucesso", "Anomalias atualizadas com sucesso.");
                    }
                }

                return new Response("Error", "Nenhuma anomalia foi atualizada.");
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao atualizar anomalias: {ex.Message}");
            }
        }





        public async Task<Response> InserirAsync(AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                await _collection.InsertOneAsync(anomaliaDiariaEntity);
                return new Response("Sucesso", "Anomalia inserida com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao inserir anomalia: {ex.Message}");
            }
        }


        public async Task<Response> InserirListaAsync(List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                await _collection.InsertManyAsync(listaAnomaliaDiariaEntity);
                return new Response("Sucesso", "Anomalias inseridas com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao inserir anomalias: {ex.Message}");
            }
        }



        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnumAsync(string idParadaAnomalia, List<AnomalyTypeDocument> listaTAnomaliaipoEnum)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.IdParadaAnomalia == idParadaAnomalia &&
                listaTAnomaliaipoEnum.Contains(anomalia.TipoAnomalia)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorListaNumeroViagemAsync(List<string> listaNumeroViagem, string idAnomaliaDiaria)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                listaNumeroViagem.Contains(anomalia.Viagem) &&
                anomalia.Id != idAnomaliaDiaria
            );

            return await _collection.Find(filter).ToListAsync();
        }


        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEAnomaliaTipoEnumAsync(string numeroViagem, AnomalyTypeDocument anomaliaTipoEnum)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                anomalia.TipoAnomalia == anomaliaTipoEnum
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEIdParadaEAnomaliaTipoEnumAsync(string numeroViagem, string idParadaAnomalia, AnomalyTypeDocument tipo)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                anomalia.IdParadaAnomalia == idParadaAnomalia &&
                anomalia.TipoAnomalia == tipo
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                anomalia.TipoAnomalia == anomalyTypeEnum &&
                anomalia.LocalAnomalia != null &&
                anomalia.LocalAnomalia.Latitude >= (latitude - raio) &&
                anomalia.LocalAnomalia.Latitude <= (latitude + raio) &&
                anomalia.LocalAnomalia.Longitude >= (longitude - raio) &&
                anomalia.LocalAnomalia.Longitude <= (longitude + raio)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEListaAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> listaTipos)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                listaTipos.Contains(anomalia.TipoAnomalia)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemEVariasAnomaliaTipoEnumAsync(string numeroViagem, List<AnomalyTypeDocument> anomaliasTipoEnum)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                anomaliasTipoEnum.Contains(anomalia.TipoAnomalia)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRota(string numeroViagem)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Viagem, numeroViagem);
            var sort = Builders<AnomaliaDiariaEntity>.Sort.Ascending(anomalia => anomalia.PrioridadeAnomalia);

            var result = await _collection.Find(filter).Sort(sort).FirstOrDefaultAsync();

            return result != null ? (1, (int)result.PrioridadeAnomalia) : (0, 0);
        }

        public async Task<AnomaliaDiariaEntity> ObterPorId(string idAnomaliaDiaria)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Id, idAnomaliaDiaria);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<AnomaliaDiariaEntity> ObterPorNumeroViagemEPseudoIdMobileAsync(string numeroViagem, string pseudoIdMobileDiario)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.Viagem == numeroViagem &&
                anomalia.PseudoIdMobileDiario == pseudoIdMobileDiario
            );

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<AnomaliaDiariaEntity> ResetarStatusAsync(AnomaliaDiariaEntity anomaliaDiaria)
        {

            anomaliaDiaria.StatusDiaria = AnomalyStatusTypeDocument.Pending;
            anomaliaDiaria.UltimaData = DateTime.UtcNow;

            var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Id, anomaliaDiaria.Id);

            var update = Builders<AnomaliaDiariaEntity>.Update
                .Set(anomalia => anomalia.StatusDiaria, AnomalyStatusTypeDocument.Pending)
                .Set(anomalia => anomalia.UltimaData, DateTime.UtcNow);

            var options = new FindOneAndUpdateOptions<AnomaliaDiariaEntity>
            {
                ReturnDocument = ReturnDocument.After  // Isso garante que o documento retornado seja o novo (pós-atualização)
            };

            return await _collection.FindOneAndUpdateAsync(filter, update, options);
        }


        public async Task<IEnumerable<AnomaliaDiariaEntity>> ObterListaPorFiltroAsync(AnomaliaDiariaEntity anomaliaRequest)
        {
            var filterBuilder = Builders<AnomaliaDiariaEntity>.Filter;
            var filter = FilterDefinition<AnomaliaDiariaEntity>.Empty; // Inicia com um filtro vazio


            if (!string.IsNullOrEmpty(anomaliaRequest.Viagem))
                filter &= filterBuilder.Eq(anomalia => anomalia.Viagem, anomaliaRequest.Viagem);

            if (anomaliaRequest.CodigoAnomalia != 0)
                filter &= filterBuilder.Eq(anomalia => anomalia.CodigoAnomalia, anomaliaRequest.CodigoAnomalia);

            if (anomaliaRequest.PrioridadeAnomaliaEditada != null)
                filter &= filterBuilder.Eq(anomalia => anomalia.PrioridadeAnomalia, anomaliaRequest.PrioridadeAnomalia);

            if (anomaliaRequest.StatusAnomaliaEditado != null)
                filter &= filterBuilder.Eq(anomalia => anomalia.StatusDiaria, anomaliaRequest.StatusDiaria);


            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorIdParadaAnomaliaEListaAnomaliaTipoEnum(string idParadaAnomalia, List<AnomalyTypeDocument> listaTAnomaliaipoEnum)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                anomalia.IdParadaAnomalia == idParadaAnomalia &&
                listaTAnomaliaipoEnum.Contains(anomalia.TipoAnomalia)
            );

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorListaGemENumeroViagem(List<string> listaNumeroViagem, string idAnomaliaDiaria)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Where(anomalia =>
                listaNumeroViagem.Contains(anomalia.Viagem) &&
                anomalia.Id != idAnomaliaDiaria
            );

            return await _collection.Find(filter).ToListAsync();
        }



        public async Task<List<AnomaliaDiariaEntity>> ObterListaPorNumeroViagemELatitudeELongitudeERaioAsync(string numeroViagem, AnomalyTypeDocument anomalyTypeEnum, double latitude, double longitude, int raio, AnomaliaDiariaEntity anomalia)
        {
            // Converte o raio de metros para graus (aproximadamente)
            double raioEmGraus = raio / 111320d;

            // Cria um filtro para número da viagem e tipo de anomalia
            var filtroViagemAnomalia = Builders<AnomaliaDiariaEntity>.Filter.And(
                Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Viagem, numeroViagem),
                Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.TipoAnomalia, anomalyTypeEnum)
            );

            Expression<Func<AnomaliaDiariaEntity, double>> value = anomalia => anomalia.LocalAnomalia.Latitude;
            var filtroGeoespacial = Builders<AnomaliaDiariaEntity>.Filter.And(
          Builders<AnomaliaDiariaEntity>.Filter.Gte(value, latitude - raioEmGraus),
          Builders<AnomaliaDiariaEntity>.Filter.Lte(anomalia => anomalia.LocalAnomalia.Latitude, latitude + raioEmGraus),
          Builders<AnomaliaDiariaEntity>.Filter.Gte(anomalia => anomalia.LocalAnomalia.Longitude, longitude - raioEmGraus),
          Builders<AnomaliaDiariaEntity>.Filter.Lte(anomalia => anomalia.LocalAnomalia.Longitude, longitude + raioEmGraus)
      );

            // Combina os filtros
            var filtroCombinado = Builders<AnomaliaDiariaEntity>.Filter.And(filtroViagemAnomalia, filtroGeoespacial);

            // Executa a consulta
            return await _collection.Find(filtroCombinado).ToListAsync();
        }




        public async Task<(int count, int prioridade)> ObterMinimoPrioridadeAnomaliasRotaAsync(string numeroViagem)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Viagem, numeroViagem);
            var sort = Builders<AnomaliaDiariaEntity>.Sort.Ascending(anomalia => anomalia.PrioridadeAnomalia);

            var result = await _collection.Find(filter).Sort(sort).FirstOrDefaultAsync();

            return result != null ? (1, (int)result.PrioridadeAnomalia) : (0, 0);
        }



        public async Task<List<AnomaliaDiariaEntity>> ObterListaAnomaliaTratativaPorNumeroViagemAsync(string numeroViagem)
        {
            var filter = Builders<AnomaliaDiariaEntity>.Filter.Eq(anomalia => anomalia.Viagem, numeroViagem);
            return await _collection.Find(filter).ToListAsync();
        }
        public async Task<Response> AtualizarAsync(AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                FilterDefinition<AnomaliaDiariaEntity> filtro = Builders<AnomaliaDiariaEntity>.Filter.Eq(a => a.Id, anomaliaDiariaEntity.Id);
                var resultado = await _collection.ReplaceOneAsync(filtro, anomaliaDiariaEntity);

                if (resultado.IsAcknowledged && resultado.ModifiedCount > 0)
                {
                    return new Response("Sucesso", "Anomalia atualizada com sucesso.");
                }
                else
                {
                    return new Response("Error", "Anomalia não encontrada ou não foi atualizada.");
                }
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao atualizar anomalia: {ex.Message}");
            }
        }

        public async Task<Response> ExcluirAsync(string idAnomaliaDiaria)
        {
            try
            {
                FilterDefinition<AnomaliaDiariaEntity> filtro = Builders<AnomaliaDiariaEntity>.Filter.Eq(a => a.Id, idAnomaliaDiaria);
                var resultado = await _collection.DeleteOneAsync(filtro);

                if (resultado.IsAcknowledged && resultado.DeletedCount > 0)
                {
                    return new Response("Sucesso", "Anomalia excluída com sucesso.");
                }
                else
                {
                    return new Response("Error", "Anomalia não encontrada ou não foi excluída.");
                }
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao excluir anomalia: {ex.Message}");
            }
        }





        #endregion
    }
}
