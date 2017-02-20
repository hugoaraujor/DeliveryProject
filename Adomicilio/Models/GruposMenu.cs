using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("GruposMenu")]
    public class GruposMenu
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string GrupoMenuDesc { get; set; }
        public int Orden { get; set; }
    }


}
