using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adomicilio.Models
{
    [Table("Especialidad")]
    public class Especialidad
    {
      [Key]
      [Column(Order = 1)]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int IdEspecialidad { get; set; }
      [Display(Name = "Especialidad")]
      public string EspecialidadDesc { get; set; }
    }
}