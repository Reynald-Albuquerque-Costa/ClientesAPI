using ClientesAPI.Src.Models;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Repositories
{
    /// <summary>
    /// <para>Resumo: Responsavel por representar ações de CRUD de transferencia</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    public interface ITransferencia
    {
        Task TransferirPixAsync(TransferenciaModel transferencia);
    }
}
