using ClientesAPI.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Src.Context
{
    /// <summary>
    /// <para>Resumo: Classe contexto, responsavel por carregar contexto e definir DbSets</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    public class ClientesContext : DbContext
    {
        #region Atributos
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<TransferenciaModel> Transferencias { get; set; }

        #endregion

        #region Construtores
        public ClientesContext(DbContextOptions<ClientesContext> options) : base(options)
        {

        }

        #endregion
    }
}
