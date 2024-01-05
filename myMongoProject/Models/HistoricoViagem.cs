using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Models
{

    public class HistoricoViagem
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Viagem { get; set; }
        public string Motivo { get; set; }
        public string AreaResposponsavel { get; set; }
        public string ClienteResponsavel { get; set; }
        public string Justificativa { get; set;}
        public string UploadFile { get; set; }
        public string Status { get; set; }
        public DateTime  DataAtualHistorico { get; set; }
        public DateTime DataAtualizacaoHistorico { get; set; }

        public HistoricoViagem() { }

        #endregion
    }
}
