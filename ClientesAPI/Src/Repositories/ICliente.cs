using ClientesAPI.Src.Models;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Repositories
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de cliente</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    public interface ICliente
    {
        Task<ClienteModel> PegarClientePeloNomeAsync(string nome);
        Task NovoClienteAsync(ClienteModel cliente);
    }
}
