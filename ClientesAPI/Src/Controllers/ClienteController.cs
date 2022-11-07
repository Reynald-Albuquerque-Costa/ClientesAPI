using ClientesAPI.Src.Models;
using ClientesAPI.Src.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Controllers
{
    [ApiController]
    [Route("api")]
    [Produces("application/json")]
    public class ClienteController : ControllerBase
    {
        #region Atributos

        private readonly ICliente _repositorio;

        #endregion 

        #region Construtores
        public ClienteController(ICliente repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Consultar cliente pelo nome
        /// </summary>
        /// <param name="nomeCliente">Nome do cliente</param>
        /// <returns>ActionResult</returns>

        [HttpGet("ConsultarCliente/{nomeCliente}")]
        public async Task<ActionResult> PegarClientePeloNomeAsync([FromRoute] string nomeCliente)
        {
            var cliente = await _repositorio.PegarClientePeloNomeAsync(nomeCliente);

            if (cliente == null)
                return NotFound(new { Mensagem = "Cliente não encontrado" });

            return Ok(cliente);

        }

        /// <summary>
        /// Cadastrar novo cliente
        /// </summary>
        /// <param name="cliente">Contrutor para criar cliente</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        /// POST /api/CadastrarCliente
        /// {
        /// "Nome": "Reynald",
        /// "Documento": "xxx.xxx.xxx-xx",
        /// "ChavePix": "123321"
        /// }
        ///
        /// </remarks>
        
        [HttpPost("CadastrarCliente")]
        public async Task<ActionResult> NovoCliente([FromBody] ClienteModel cliente)
        {
            await _repositorio.NovoClienteAsync(cliente);

            return Created($"api/Clientes/{cliente.Nome}", cliente);
        }

        #endregion
    }
}
