using ClientesAPI.Src.Context;
using ClientesAPI.Src.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Repositories.Implements
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ICliente</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    public class ClienteRepository : ICliente
    {
        #region Atributos

        private readonly ClientesContext _contexto;

        #endregion 


        #region Contrutores
        public ClienteRepository(ClientesContext contexto)
        {
            _contexto = contexto;
        }

        #endregion 


        #region Métodos
        public async Task<ClienteModel> PegarClientePeloNomeAsync(string nome)
        {
            return await _contexto.Clientes.FirstOrDefaultAsync(c => c.Nome == nome);
        }

        public async Task NovoClienteAsync(ClienteModel cliente)
        {
            await _contexto.Clientes.AddAsync(
                new ClienteModel
                {
                    Nome = cliente.Nome,
                    Documento = cliente.Documento,
                    ChavePix = cliente.ChavePix,
                });
            await _contexto.SaveChangesAsync();

        }

        #endregion 
    }
}
