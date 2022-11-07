using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_tranferencias no banco de dados.</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>

    [Table("tb_tranferencias")]
    public class TransferenciaModel
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("fk_clienteOrigem")]
        public ClienteModel ChavePixOrigem { get; set; }

        public decimal Valor { get; set; }

        [ForeignKey("fk_clienteDestino")]
        public ClienteModel ChavePixDestino { get; set; }

        #endregion
    }
}
