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

    public class EnvioInformacoesDiariasRepository : IEnvioInformacoesDiariasRepository 
    {
        #region Propriedades
        private readonly string _connectionString = "mongodb://localhost:27017";
        private readonly string _databaseName = "BancoUm";

        private readonly IMongoCollection<EnvioInformacoesDiarias> _collection;

        public EnvioInformacoesDiariasRepository()
        {
            var client = new MongoClient(_connectionString);
            var database = client.GetDatabase(_databaseName);
            _collection = database.GetCollection<EnvioInformacoesDiarias>("envioInformacoesDiarias");
        }

        public async Task<EnvioInformacoesDiarias> ObterPorIdAsync(string IdInformacoes)
        {
            return await _collection.Find(a => a.Id == IdInformacoes).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EnvioInformacoesDiarias>> FindAllAsync()
        {
            var envioInformacoesDiarias = await _collection.Find(_ => true).ToListAsync();
            return envioInformacoesDiarias;
        }

        public async Task<Response> InserirAsync(EnvioInformacoesDiarias envioInformacoesDiarias)
        {
            try
            {
                await _collection.InsertOneAsync(envioInformacoesDiarias);
                return new Response("Sucesso",
                   "Historico Viagem inserido com sucesso.");
            }
            catch (Exception ex)
            {
                return new Response("Error", $"Erro ao inserir anomalia: {ex.Message}");
            }
        }

        public async Task<List<EnvioInformacoesDiarias>> ObterListaPorNumeroViagemAsync(string numeroViagem)
        {
            return await _collection.Find(a => a.Viagem == numeroViagem).ToListAsync();
        }

   
        #endregion
    }
}
