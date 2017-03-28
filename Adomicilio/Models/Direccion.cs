using Adomicilio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
namespace Adomicilio.Models
{
    [Table("Direccion")]
    public class Direccion
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDireccion { get; set; }
        public int IdUser { get; set; }
        [Required]
        public string Calle { get; set; }
        [Required]
        public string CasaNro { get; set; }
        [Required]
        public string Urbanizacion { get; set; }
        public string referencia { get; set; }
        public string Alias { get; set; }
    }

    public class RegistroUser
    {
        public RegistroUser()
        {
            //var x=usuario==null? usuario.Id:0;
       //     direcciones = GetDirecciones(x);
           
        }
      public  ApplicationUser usuario { get; set; }
        public List<Direccion> direcciones { get; set; }
       
        public static List<Direccion> GetDirecciones(int usuarioId)
        {
            List<Direccion> direcciones = new List<Direccion>();
            direcciones.Find(x => x.IdUser == usuarioId);
            return direcciones;
        }
        public static List<Pais> GetPaises()
        {
            List<Pais> paises = new List<Pais>();
            return paises;
        }
        public static List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();
            return estados;
        }
        public static List<Sector> GetSectores()
        {
            List<Sector> sectores = new List<Sector>();
            return sectores;
        }
        public static Pais GetPais(int paisId)
        {
            var query = GetPaises();
            foreach (var Pais in query)
            {
                if (Pais.IdPais == paisId)
                {
                    return Pais;
                }
            }

            return null;
        }

    }
    [Table("SubCategorias")]
    public class SubCategorias
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Subcategory { get; set; }
        public int IdCategory { get; set; }
        public string SubCategoryName { get; set; }

    }
    [Table("Publicidad")]
    public class Publicidad
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idpub { get; set; }
        public string Mensajeenletras { get; set; }
        public byte[] Imagenbanner { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime Desde { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime HastaFecha { get; set; }
        public long clicks { get; set; }

    }

    public class Orden
    {
        public Orden()
        {
            //   DateCreated = DataExtension.MinValue();
            //
        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrdenNro { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public System.DateTime? DateCreated { get; set; }
       
       
        private Procesadostat status;

        public Procesadostat GetStatus()
        {
            return status;
        }

        public void SetStatus(Procesadostat value)
        {
            status = value;
        }
    }

    [Table("Compra")]
    public class Compra
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrdenNro { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateDispatched { get; set; }
        public System.DateTime? DateCreated { get; set; }
        [ForeignKey("Buyer")]
        public int UId { get; set; }
        public int IdDireccion { get; set; }
        public string Idsession { get; set; }
        public TipoPago tipopago { get; set; }
        [ForeignKey("IdDireccion")]
        public virtual Direccion Adireccion { get; set; }
        public virtual  ApplicationUser  Buyer { get; set; }
        public virtual decimal monto { get; set; }
        public virtual bool pagoconfirmado{ get; set; }
        public string session { get; set; }
        public int via { get; set; }
    }
   
    [Table("EmpresaSector")]
    public class EmpresaSector
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int Sectorid { get; set; }
        public bool Activo { get; set; }
    }
    [Table("General")]
    public class General
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public long  OrdenNro { get; set; }
        public string TerminosdeUso { get; set; }
        public string Privacidad { get; set; }
    }
    [Table("PreguntasUsuario")]
    public class PreguntasUsuario
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        
    }
    [Table("PreguntasComercio")]
    public class PreguntasComercio
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdPregunta { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

    }
    [Table("Invitaciones")]
    public class Amigo
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idinvite { get; set; }
        public int UId { get; set; }
        public string email { get; set; }
        public bool Aceptada { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        
        public System.DateTime? DateCreated { get; set; }
        public System.DateTime? DateAccept { get; set; }
        [ForeignKey("UId")]
        public virtual ApplicationUser usuario { get; set; }
    }
    [Table("Afiliaciones")]
    public class AFiliaciones
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int afiliaId { get; set; }
        public int UId { get; set; }
        public int Idinvite { get; set; }
        public bool Aceptada { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public System.DateTime? DateCreated { get; set; }
        [ForeignKey("UId")]
        public virtual ApplicationUser usuario { get; set; }
        
    }
    [Table("Chat")]
    public class Chat
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdChat { get; set; }
        public int UId { get; set; }
        public string Mensaje { get; set; }
        [ForeignKey("UId")]
        public virtual ApplicationUser usuario { get; set; }
        

    }
    [Table("Opiniones")]
    public class Opinion
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Idopinion { get; set; }
        public int UId { get; set; }
        public int SubId { get; set; }
        public int IdProducto { get; set; }
        public string Comentario { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<Menu> menus { get; set; }
        [ForeignKey("UId")]
        public virtual ApplicationUser usuario { get; set; }
         
}
[Table("Estadistica")]
    public class Estadistica
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstadisticaId { get; set; }
        public int Id { get; set; }
        public Decimal MontoenCompras { get; set; }
        public Decimal NumerodeCompras { get; set; }
        public int recomendaciones { get; set; }
        public int recomendacionesaceptadas { get; set; }
        public int recomendacionesrechazadas { get; set; }
       // public virtual ApplicationUser usuario { get; set; }
    }
    [Table("Notificaciones")]
    public class Notificaciones
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotifyId { get; set; }
        public int UId { get; set; }
        public string Mensaje { get; set; }
        public bool vista { get; set; }
        public  tipodenotificacionenum tipo { get; set; }
        [ForeignKey("UId")]
        public virtual ApplicationUser usuario { get; set; }

    }
    [Table("Sugerencias")]
    public class Sugest
    {
        public Sugest()
        {
       //     DateCreated = DateTime.Now;

        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSugest { get; set; }
        public string Telefono { get; set; }
        public string Contacto { get; set; }
        public string Negocio { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public System.DateTime? DateCreated {get; set; }
  
    }

    public class EmailFormModel
    {

        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
        public System.Web.HttpPostedFileBase Upload { get; set; }

    }

    [Table("Emails")]
    public class Emails
    {

        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime Added { get; set; }
        [System.Web.Mvc.AllowHtml]
        public string Descripcion { get; set; }
        public string Subject { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }

    public class Valoracion
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int UserId { get; set; }
        public int puntos { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        public System.DateTime? DateCreated { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }

}
