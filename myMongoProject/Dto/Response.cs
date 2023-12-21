using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace myMongoProject.Dto
{
    public class Response
    {
        #region Propriedades


        public string Sucesso { get; set; }
        public string Mensagem { get; set; }

        public Response(string sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }



        #endregion
    }
}
