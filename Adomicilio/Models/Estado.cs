using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    
    [Table("Estado")]
    public class Estado
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstado { get; set; }
        public string estado { get; set; }
        public int IdPais { get; set; }
      


    }
   
   
    

}
