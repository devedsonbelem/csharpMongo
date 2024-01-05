using Microsoft.AspNetCore.Mvc;
using myMongoProject.Dto;
using myMongoProject.Exceptions;
using myMongoProject.Models;
using myMongoProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myMongoProject.Controllers
{
    

    [Route("api/historico")]
    [ApiController]
    public class HistoricoViagemController : ControllerBase
    {
        #region Propriedades

        private readonly IHistoricoViagemService _service;
        private readonly ILogger<HistoricoViagemController> _logger;
        public HistoricoViagemController(IHistoricoViagemService service, ILogger<HistoricoViagemController> logger)
        {
            _service = service;
            _logger = logger;
        }



        [HttpGet("listar-todoshistoricos")]
        public async Task<ActionResult<IEnumerable<HistoricoViagem>>> ListarTodosHistoricos()
        {
            var resultados = await _service.FindAllAsyncService();
            return Ok(resultados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoViagem>> ObterPorIdAsync(string id)
        {
            try
            {
                var historico = await _service.ObterPorIdAsyncService(id);
                return Ok(historico);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Response>> InserirAsync([FromBody] HistoricoViagem historicoViagem)
        {
            try
            {
                var resultado = await _service.InserirAsyncService(historicoViagem);
                return Ok(resultado);
            }
            catch (InsertFailedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion
    }
}