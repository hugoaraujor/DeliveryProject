using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("Contactanos")]
    public class Contacto
    {
        public Contacto()
        {
            DateCreated = DateTime.Now;

        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContact { get; set; }
        [Display(Name = "Telefono de Contacto (opcional)")]
        public string Telefono { get; set; }
        [Required]
        [Display(Name = "Su Nombre")]
        public string Nombre { get; set; }
        [Display(Name = "Motivo")]
        public  tipodecontacto TipodeContacto { get; set; }
        [Required]
        [Display(Name = "Su Mensaje")]
        public string Descripcion { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
         public string email { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public bool nuevo;
        public bool respondido;

    }


}
