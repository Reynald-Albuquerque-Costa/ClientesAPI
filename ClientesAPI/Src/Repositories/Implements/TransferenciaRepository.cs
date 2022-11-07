using ClientesAPI.Src.Context;
using ClientesAPI.Src.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesAPI.Src.Repositories.Implements
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por implementar ITransferencia</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    public class TransferenciaRepository : ITransferencia
    {
        #region Atributos

        private readonly ClientesContext _contexto;

        #endregion 


        #region Contrutores
        public TransferenciaRepository(ClientesContext contexto)
        {
            _contexto = contexto;
        }

        #endregion 


        #region Métodos
        public async Task TransferirPixAsync(TransferenciaModel transferencia)
        {
            if (!ExisteNomeChavePixOrigem(transferencia.ChavePixOrigem.Nome)) throw new Exception("Cliente origem não encontrado");

            if (!ExisteNomeChavePixDestino(transferencia.ChavePixDestino.Nome)) throw new Exception("Cliente destino não encontrado");

            await _contexto.Transferencias.AddAsync(new TransferenciaModel
            {
                ChavePixOrigem = _contexto.Clientes.FirstOrDefault(t => t.Nome == transferencia.ChavePixOrigem.Nome),
                Valor = transferencia.Valor,
                ChavePixDestino = _contexto.Clientes.FirstOrDefault(t => t.Nome == transferencia.ChavePixDestino.Nome),

            });
            await _contexto.SaveChangesAsync();

            //Função Auxiliar
            bool ExisteNomeChavePixDestino(string nome)
            {
                var auxiliar = _contexto.Clientes.FirstOrDefault(t => t.Nome == nome);

                return auxiliar != null;
            }

            bool ExisteNomeChavePixOrigem(string nome)
            {
                var auxiliar = _contexto.Clientes.FirstOrDefault(t => t.Nome == nome);

                return auxiliar != null;
            }

        }

        #endregion 
    }
}
