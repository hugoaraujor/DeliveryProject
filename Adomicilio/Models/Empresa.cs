using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
   

    [Table("Empresa")]
    public class Empresa
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Empresa()
        {
            Activa = true;
         
        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Required]
        [Display(Name = "Nombre del Negocio/Restaurante:")]
        public string RazonSocial { get; set; }

        [Display(Name = "RIF:")]
        public string RIF { get; set; }

        public string Telefonos { get; set; }

        [Display(Name = "Descripción Corta o Slogan:")]
        public string Slogan { get; set; }

        public int Valoracion { get; set; }

        [Display(Name = "Tipo de Negocio:")]
        public int CategoriaLocal { get; set; }

        [Display(Name = "Especialidad:")]
        public int TipodeComida { get; set; }

        public int like { get; set; }

        [Display(Name = "Dirección:")]
        public string Direccion { get; set; }

        [Display(Name = "Horario de Trabajo:")]
        public string horario1 { get; set; }

        [Display(Name = "Tiempo Promedio de Preparación:")]
        public int Delivery { get; set; }

        [Display(Name = "Persona Contacto:")]
        public string Contacto { get; set; }

        [Display(Name = "Archivo de Logo:")]
        public byte[] logo { get; set; }

        public bool Activa { get; set; }

      
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }

        
        [Display(Name = "Fecha Editado")]
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateEdited { get; set; }
        
        [Display(Name = "Tipo Delivery")]
        public Tipodelivery tipodelivery { get; set; }

        [Display(Name = "Ciudad")]
        public int idCiudad { get; set; }

        [Display(Name = "Estado")]
        public int idEstado { get; set; }

        [Display(Name = "Sectores")]
        public string Sectores { get; set; }

        [Display(Name = "Imagen URL")]
        public string imagenurl { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }

       
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string claveuser { get; set; }

        public string ip { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual List<EmpresaSector> SectoresAtendidos { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Menu> menus { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Valoracion> valoraciones { get; set; }
        public virtual bool abierto { get; set; }

        public bool GetOpenOrClose(int idempresa)
        {
            var _localDate = DateTime.SpecifyKind(DateTime.Now.ToLocalTime(), DateTimeKind.Utc);
            int daynumber = (int)System.DateTime.Now.DayOfWeek;
            Console.WriteLine(idempresa);
            DateTime fin = new DateTime();
            if (this != null)
            {
                var query = from a in db.Horarios where (a.IdEmpresa == idempresa && ((int)a.dia) == daynumber) select a;

                fin = DateTime.Now;
                if (query.Count>0)
                    fin = query.DefaultIfEmpty().Single().EndtHour;
                                Console.WriteLine(fin);
            }
            if (fin == null)
                return false;
            else
                return (_localDate < fin);
        }
    }

    [Table("TipoEmpresa")]
    public class TipoEmpresa
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TipodeLocal { get; set; }
        }
   

    public class EmpresaCatalog
    {

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }

        [Required]
        [Display(Name = "Nombre del Negocio/Restaurante:")]
        public string RazonSocial { get; set; }

        [Display(Name = "RIF:")]
        public string RIF { get; set; }

        public string Telefonos { get; set; }

        [Display(Name = "Descripción Corta o Slogan:")]
        public string Slogan { get; set; }

        public int Valoracion { get; set; }

        [Display(Name = "Tipo de Negocio:")]
        public int CategoriaLocal { get; set; }

        [Display(Name = "Especialidad:")]
        public int TipodeComida { get; set; }

        public int like { get; set; }

        [Display(Name = "Dirección:")]
        public string Direccion { get; set; }

        [Display(Name = "Horario de Trabajo:")]
        public string horario1 { get; set; }

        [Display(Name = "Tiempo Promedio de Preparación:")]
        public int Delivery { get; set; }

        [Display(Name = "Persona Contacto:")]
        public string Contacto { get; set; }

        [Display(Name = "Archivo de Logo:")]
        public byte[] logo { get; set; }

        public bool Activa { get; set; }

        [Display(Name = "Creado")]
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }


        [Display(Name = "Editado")]
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateEdited { get; set; }

        [Display(Name = "Tipo Delivery")]
        public Tipodelivery tipodelivery { get; set; }

        [Display(Name = "Ciudad")]
        public int idCiudad { get; set; }

        [Display(Name = "Estado")]
        public int idEstado { get; set; }

        [Display(Name = "Sectores")]
        public string Sectores { get; set; }

        [Display(Name = "Imagen URL")]
        public string imagenurl { get; set; }

        [Display(Name = "User")]
        public string User { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string claveuser { get; set; }

        public string ip { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual List<EmpresaSector> SectoresAtendidos { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Menu> menus { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Valoracion> valoraciones { get; set; }

        public List<GruposMenu> grupomenu { get; set; }
        public List<Menu> menu { get; set; }

        public string tipodecomidastr { get; set; }






        public static List<GruposMenu> GetGrupos()
        {
            List<GruposMenu> grupos = new List<GruposMenu>();
            return grupos;
        }

    }
}
