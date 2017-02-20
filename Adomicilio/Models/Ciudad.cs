using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("Ciudades")]
    public class Ciudad
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CiudadId { get; set; }
        public string ciudad { get; set; }
        public int IdEstado { get; set; }

    }
   
   
    

}
