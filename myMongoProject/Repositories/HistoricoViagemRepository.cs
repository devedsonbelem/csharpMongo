using MongoDB.Driver;
using myMongoProject.Dto;
using myMongoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Repositories
{
    public class HistoricoViagemRepository : IHistoricoViagemRepository
    {

        #region Propriedades
        private readonly string _connectionString = "mongodb://localhost:27017";
        private readonly string _databaseName = "BancoUm";
        string Sucesso = "sucesso";
        private object projection;


        private readonly IMongoCollection<HistoricoViagem> _collection;

        public HistoricoViagemRepository()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<HistoricoViagem>("historicoviagens");
        }




        public async Task<HistoricoViagem> ObterPorIdAsync(string IdHistorico)
        {
            return await _collection.Find(a => a.Id == IdHistorico).FirstOrDefaultAsync();
        }

        public async Task<List<HistoricoViagem>> ObterListaPorNumeroViagemAsync(string numeroViagem)
        {
            return await _collection.Find(a => a.Viagem == numeroViagem).ToListAsync();
        }

        public async Task<Response> InserirAsync(HistoricoViagem historicoViagem)
        {
            try
            {
            
               await _collection.InsertOneAsync(historicoViagem);
                return new Response("Sucesso",
                   "Historico Viagem inserido com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao inserir anomalia: {ex.Message}");
            }
        }
      

        public async   Task<IEnumerable<HistoricoViagem>> FindAllAsync()
        {
            var historicos = await _collection.Find(_ => true).ToListAsync();
            return historicos;
        }

        

        #endregion Propriedades
    }

}