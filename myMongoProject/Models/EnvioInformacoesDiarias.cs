using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace myMongoProject.Models
{
   public class EnvioInformacoesDiarias
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Viagem { get; set; }



        public string TempoEmDiaria { get; set; }
        public double PesoEntrega { get; set; }

        public string NomeCliente { get; set; }

        public string EntregaViagem { get; set; }

        public int Quantidade { get; set; }

        public string MotivoViagem { get; set; }

        public string SubMotivo { get; set; }

        public string AreaReponsavel { get; set; }

        public string ClienteResponsavel { get; set; }

        public string Status { get; set; }
        #endregion
    }
}
