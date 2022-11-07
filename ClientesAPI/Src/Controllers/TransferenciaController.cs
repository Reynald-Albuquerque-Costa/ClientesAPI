using ClientesAPI.Src.Models;
using ClientesAPI.Src.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class TransferenciaController : ControllerBase
    {
        #region Atributos

        private readonly ITransferencia _repositorio;

        #endregion 

        #region Construtores
        public TransferenciaController(ITransferencia repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Transferir Pix
        /// </summary>
        /// <param name="transferencia">Contrutor para criar transferência</param>
        /// <returns>ActionResult</returns>

        [HttpPost("TransferirPix")]
        public async Task<ActionResult> TransferirPix([FromBody] TransferenciaModel transferencia)
        {
            try
            {
                await _repositorio.TransferirPixAsync(transferencia);
                return Created($"api/Transferencia", transferencia);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }

        #endregion
    }
}
