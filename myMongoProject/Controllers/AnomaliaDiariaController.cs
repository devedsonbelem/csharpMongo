using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using myMongoProject.Models;
using myMongoProject.Service;
using myMongoProject.Exceptions;
using myMongoProject.Dto;
namespace myMongoProject.Controllers
{

    #region Propriedades
    [Route("api/anomalias")]
    [ApiController]
    public class AnomaliaDiariaController : ControllerBase
    {
        private readonly IAnomaliaDiariaService _service;
        private readonly ILogger<AnomaliaDiariaController> _logger;
        public AnomaliaDiariaController(IAnomaliaDiariaService service, ILogger<AnomaliaDiariaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnomaliaDiariaEntity>> ObterPorIdAsync(string id)
        {
            try
            {
                var anomalia = await _service.ObterPorIdAsync(id);
                return Ok(anomalia);
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
 

        [HttpPost("atualizar")]
        public async Task<ActionResult<Response>> AtualizarAsync([FromBody] AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _service.AtualizarAsync(anomaliaDiariaEntity);
                return Ok(resultado);
            }
            catch (UpdateFailedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("atualizar-lista")]
        public async Task<ActionResult<Response>> AtualizarListaAsync([FromBody] List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _service.AtualizarListaAsync(listaAnomaliaDiariaEntity);
                return Ok(resultado);
            }
            catch (UpdateFailedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> ExcluirAsync(string id)
        {
            try
            {
                var resultado = await _service.ExcluirAsync(id);
                return Ok(resultado);
            }
            catch (DeleteFailedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ServiceException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("inserir")]
        public async Task<ActionResult<Response>> InserirAsync([FromBody] AnomaliaDiariaEntity anomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _service.InserirAsync(anomaliaDiariaEntity);
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

        [HttpPost("inserir-lista")]
        public async Task<ActionResult<Response>> InserirListaAsync([FromBody] List<AnomaliaDiariaEntity> listaAnomaliaDiariaEntity)
        {
            try
            {
                var resultado = await _service.InserirListaAsync(listaAnomaliaDiariaEntity);
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
 
 

        [HttpPost("resetar-status")]
        public async Task<ActionResult<AnomaliaDiariaEntity>> ResetarStatusAsync([FromBody] AnomaliaDiariaEntity anomaliaDiaria)
        {
            try
            {
                var anomalia = await _service.ResetarStatusAsync(anomaliaDiaria);
                return Ok(anomalia);
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




        #endregion
    }

}

