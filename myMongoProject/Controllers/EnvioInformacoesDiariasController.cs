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
    [Route("api/envio")]
    [ApiController]
    public class EnvioInformacoesDiariasController : ControllerBase
    {
        #region Propriedades

        private readonly IEnvioInformacoesDiariasService _service;
        private readonly ILogger<EnvioInformacoesDiariasController> _logger;
        public EnvioInformacoesDiariasController(IEnvioInformacoesDiariasService  service, ILogger<EnvioInformacoesDiariasController> logger)
        {
            _service = service;
            _logger = logger;
        }



        [HttpGet("listar-todasInformacoes")]
        public async Task<ActionResult<IEnumerable<EnvioInformacoesDiarias>>> ListarTodosHistoricos()
        {
            var resultados = await _service.FindAllAsyncService();
            return Ok(resultados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioInformacoesDiarias>> ObterPorIdAsync(string id)
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
        public async Task<ActionResult<Response>> InserirAsync([FromBody] EnvioInformacoesDiarias envioInformacoesDiarias)
        {
            try
            {
                var resultado = await _service.InserirAsyncService(envioInformacoesDiarias);
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
