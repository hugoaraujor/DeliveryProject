using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("CarritodeCompras")]
    public class CarritodeCompras
    {
        public CarritodeCompras()
        {
            //        DateCreated= DateTime.Now;

        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string sessionid { get; set; }
        public string clase { get; set; }
        public int IdProducto { get; set; }
        public int UserId { get; set; }
        public int  Cant { get; set; }
        public Decimal Precio{ get; set; }
        public String Mensaje { get; set; }
        public String ingredientes { get; set; }
        public String Extra { get; set; }
        
    }


}
