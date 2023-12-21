using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myMongoProject.Dto
{
    public class AnomaliaDiariaRequest : PaginationRequest
    {
             #region Propriedades

            public string Logistica { get; set; }

            public List<string> NumeroViagens { get; set; }

            public List<string> Placas { get; set; }

            public List<string> Unidades { get; set; }

            public List<string> Clientes { get; set; }

            public List<string> Transportadora { get; set; }

            public string Placa { get; set; }

           

            public DateTime? DtCreatedStart { get; set; }

            public DateTime? DtCreatedEnd { get; set; }

 

            #endregion
        }

    }
 
