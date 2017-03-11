using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("MenuIngredients")]
    public class MenuIngredients
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdIngrediente { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public bool Requerido { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<Menu> Producto { get; set; }
    }


}
