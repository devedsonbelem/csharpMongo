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
using System.Reflection.Metadata;
using System.Diagnostics;
using System.ComponentModel;

namespace myMongoProject.Models
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class AnomaliaDiariaEntity  
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("DataAnomalia")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DataAnomalia { get; set; } 
        public string PseudoIdMobileDiario { get; set; }
        public string Viagem { get; set; }
        public int CodigoAnomalia { get; set; }
        public string PrioridadeAnomaliaEditada { get; set; }
        public string StatusAnomaliaEditado { get; set; }
        public string TipoAnomaliaEditado { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PriorityTypeDocument PrioridadeAnomalia { get; set; }
        public string StatusDiaria { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AnomalyTypeDocument TipoAnomalia { get; set; }
        public string Placa { get; set; }
        public string TipoOperacao { get; set; }
        public string CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public string ContatoComercial { get; set; }
        [BsonIgnore]
        public string TemChat { get; set; }
        public string IdChat { get; set; }
        public string NomeChat { get; set; }
        public string TopicoId { get; set; }
        public string IdTransportadora { get; set; }
        public string Transportadora { get; set; }
        public string IdUsuarioFiltro { get; set; }
        public string NomeUsuarioFiltro { get; set; }
        public string NomeFiltro { get; set; }
        public string TelefoneUsuario { get; set; }
        public string CpfMotorista { get; set; }
        public string MotoristaCodigo { get; set; }
        public string NomeMotorista { get; set; }
        public string TelefoneMotorista { get; set; }
        public string Rastreador { get; set; }
        public string Gprs { get; set; }
        public string IdTratativa { get; set; }
        public string Tratativa { get; set; }
        [BsonElement("DataDiaria ")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DataDiaria { get; set; }
        public string EnvioAprovacao { get; set; }
        public string Motivo { get; set; }
        public string SubMotivo { get; set; }
        public string AreaResponsavel { get; set; }

        public string ClienteResponsavel { get; set; }

        public string Justificativa { get; set; }

        public string AprovacaoViagem { get; set; }

        public string TempoDiaria { get; set; }

        public double PesoCarga { get; set; }

        public string Entrega { get; set; }

        public string IdParadaAnomalia { get; set; }

        [BsonElement("LocalAnomalia")]
        public EnderecoDocument LocalAnomalia { get; set; }

        public IEnumerable<TratativaDocument> Tratativas { get; set; }

        [BsonElement("DataSaida")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DataSaida { get; set; }

        [BsonElement("DataPrevisaoChegada")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DataPrevisaoChegada { get; set; }

        [BsonElement("ultimaData")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.String)]
        public DateTime UltimaData { get; set; }

        public AnomaliaDiariaEntity(string viagem)
        {
            Viagem = viagem;
        }

       

        public AnomaliaDiariaEntity(string idAnomaliaDiaria, string viagem, string placa)
        {
            Id = idAnomaliaDiaria;
            Viagem = viagem;
            Placa = placa;
        }

        public AnomaliaDiariaEntity(string idAnomaliaDiaria, string viagem, string placa, string idParadaAnomalia)
        {
            Id = idAnomaliaDiaria;
            Viagem = viagem;
            Placa = placa;
            IdParadaAnomalia = idParadaAnomalia;
        }


        public override bool Equals(object obj)
        {
            return obj is AnomaliaDiariaEntity entity &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        #endregion
    }




    public class EnderecoDocument
    {
        #region Propriedades 
        public string Rua { get; set; }

        public string Complemento { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Zip { get; set; }

        public string ExtendedPostalCode { get; set; }

        public string Pais { get; set; }

        public  double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Uf
        {
            get
            {
                return Estado;
            }
            set
            {
                Estado = value;
            }
        }

        public string Cep
        {
            get
            {
                return ExtendedPostalCode;
            }
            set
            {
                ExtendedPostalCode = value;
            }
        }
        #endregion

    }
    public class MotivoDevolucaoDocument
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Codigo { get; set; }

        public string Motivo { get; set; }

        public string Descricao { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public ReasonReturnCategoryTypeDocument Categoria { get; set; }
        #endregion
    }



    public class TratativaDocument
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UsuarioMonitorNome { get; set; }

        public string UsuarioMonitorEmail { get; set; }

        public string Justificativa { get; set; }

        public string PasswordDevolution { get; set; }

        public decimal? LatitudeNovaCoordenada { get; set; }

        public decimal? LongitudeNovaCoordenada { get; set; }

        public string RaioNovaCoordenada { get; set; }

        public string PaisNovaCoordenada { get; set; }

        public string EstadoNovaCoordenada { get; set; }
        public string CidadeNovaCoordenada { get; set; }

        public bool Visualizado { get; set; }

        public DateTime DtCreated { get; set; }

        public DateTime DtValidade { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TreatrativeStandbyTypeDocument? RevisarEm { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserActionTypeDocument? AcaoMotorista { get; set; }

        public MotivoDevolucaoDocument MotivoDevolucao { get; set; }

        public MotivoTratativaDocument Motivo { get; set; }

        public List<string> Anexos { get; set; }
        #endregion

    }
    public class MotivoTratativaDocument
    {
        #region Propriedades
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Categoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MotivoTratativaTypeDocument TipoMotivoTratativa { get; set; }
        #endregion
    }

    public enum MotivoTratativaTypeDocument
    {   
        DESVIO_COMPORTAMENTAL = 1,
        PARADA_NAO_PROGRAMADA = 2,
        ATRASO_DESGARCA_VD = 3,
        ENTREGA_FORA_DO_RAIO = 4,
        OUTROS = 999
    }

    public enum UserActionTypeDocument
    {
        WaitingInstructions = 0,
        AcceptReturn = 1,
        AuthorizeUserReturn = 2
    }


    public enum TreatrativeStandbyTypeDocument
    {
        min5 = 0,
        min10 = 1,
        min15 = 2,
        min20 = 3,
        min25 = 4,
        min30 = 5
    }
    public enum PriorityTypeDocument
    {
        High = 0,
        Medium = 1,
        Low = 2
    }
    public enum ReasonReturnCategoryTypeDocument
    {
        Transporte = 0,
        Armazem = 1,
        Roteirizacao = 2,
        Comercial = 3,
        Producao = 4,
        Fiscal = 5,
        SinistroBO = 6,
        Controladoria = 7,
        ProgramacaoDRPCustomer = 8,
        UPS = 9
    }
   


    public enum AnomalyTypeDocument
    {
        NotExpectedStopPoint = 0,
        HighTemperature = 1,
        TotalReturn = 2,
        PartialReturn = 3,
        Fatigue = 4, //Não utilizado
        DataDivergenteAgenda = 5,  //Não utilizado
        SemAgendaVD = 6,
        PlacaBloqueada = 7,  //Não utilizado
        AtrasoNoTransito = 8,
        SemEspelhamento = 9,
        EficienciaTemperaturaAbaixo70 = 10,
        EficienciaTemperaturaAbaixo80 = 11,
        AtrasoNaAgenda = 12,
        AtrasoNaApresentacao = 13,  //Não utilizado
        DuplicidadeDeAlocacao = 14, //Não utilizado
        AlocacaoDistante = 15,  //Não utilizado
        CaracolAcionado = 16,  //Não utilizado
        CaracolAcionadoEmMovimento = 17, //Não utilizado
        CaracolViolado = 18, //Não utilizado
        EntregaForaDoRaio = 19,
        QuebraSequencia = 20,
        DemoranoCliente = 21,
        FinalizacaoViagemForaDoRaio = 22,
        BotaoPanico = 23,
        AnomaliaNaRota = 24,
        AtrasoNaDescargaVD = 25,
        ChegadaAntecipadaVD = 26,
        AtrasoNaDescargaCD = 27,  //Não utilizado
        ChegadaAntecipadaCD = 28,
        AtrasoNoCarregamento = 29, //Não utilizado
        GaiolaAcionada = 30, //Não utilizado
        GaiolaAcionadaEmMovimento = 31, //Não utilizado
        GaiolaViolada = 32, //Não utilizado
        BauAcionado = 33, //Não utilizado
        BauAcionadoEmMovimento = 34, //Não utilizado
        EntradaEmPontoIndevido = 35, //Não utilizado
        DestinoNaoVisitado = 36,  //Não utilizado
        ParadaForaPonto = 37,  //Não utilizado
        CaracolAcionadoForaDestino = 38,  //Não utilizado
        RemessaDiferenteAgenda = 39, //Não utilizado
        DesvioTemperatura = 40, //Não utilizado
        GaiolaAcionadaForaDestino = 41, //Não utilizado
        BauAcionadoForaDestino = 42, //Não utilizado
        BauViolado = 43,  //Não utilizado
        Higienizacao = 44,  //Não utilizado
        HigienizacaoComprometida = 45,  //Não utilizado
        AtrasoNoDescarregamento = 46, //Não utilizado
        HigienizacaoSemanal = 47, //Não utilizado
        AtrasoNaRota = 47 //Não utilizado
    }
 
}
