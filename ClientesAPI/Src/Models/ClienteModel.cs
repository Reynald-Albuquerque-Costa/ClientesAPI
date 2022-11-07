using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ClientesAPI.Src.Models
{
    /// <summary>
    /// <para>Resumo: Classe responsavel por representar tb_clientes no banco de dados.</para>
    /// <para>Criado por: Reynald</para>
    /// </summary>
    
    [Table("tb_clientes")]
    public class ClienteModel
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string ChavePix { get; set; }

        [JsonIgnore, InverseProperty("ChavePixOrigem")]
        public List<TransferenciaModel> ClienteOrigem { get; set; }

        [JsonIgnore, InverseProperty("ChavePixDestino")]
        public List<TransferenciaModel> ClienteDestino { get; set; }

        #endregion
    }
}
