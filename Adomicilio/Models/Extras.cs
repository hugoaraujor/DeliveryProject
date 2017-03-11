using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("Extras")]
    public class Extras
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAdicional { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public Decimal Precio { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<Menu> Producto { get; set; }
    }


}
