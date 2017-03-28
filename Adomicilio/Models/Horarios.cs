using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI;

namespace Adomicilio.Models
{
   
    [Table("Horarios")]
  
    public class Horarios
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Required(ErrorMessage = "No se ha especificado empresa")]
         public int IdEmpresa { get; set; }
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        [Required(ErrorMessage = "No se ha especificado dia")]
        public diaenum dia{ get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartHour { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndtHour { get; set; }

        


    }

    public class HorariosViewModel
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Required(ErrorMessage = "No se ha especificado empresa")]
        public int IdEmpresa { get; set; }
        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        [Required(ErrorMessage = "No se ha especificado dia")]
        [Display(Name = "Día")]
        public diaenum dia { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [Display(Name = "Abre")]
        public DateTime StartHour { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Cierra")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndtHour { get; set; }
        public virtual List<Horarios> loshorarios { get; set; }
    }



}
