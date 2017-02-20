using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("Sector")]
    public class Sector
    {
        public int Id { get; set; }
        public string Nombresector { get; set; }
        public int CiudadId { get; set; }

    }
   
   
    

}
