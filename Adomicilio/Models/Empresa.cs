using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{


    [Table("Empresa")]
    public class Empresa
    {
        public Empresa()
        {
            Activa = true;
         
        }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEmpresa { get; set; }
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
        [ForeignKey("IdEmpresa")]
        public virtual List<EmpresaSector> SectoresAtendidos { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Menu> menus { get; set; }
        [ForeignKey("IdEmpresa")]
        public virtual List<Valoracion> valoraciones { get; set; }
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

        public int IdEmpresa { get; set; }
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
        public string TipoLocal { get; set; }
        public int like { get; set; }
        [Display(Name = "Dirección:")]
        public string Direccion { get; set; }
        [Display(Name = "Horario de Trabajo:")]
        public string horario1 { get; set; }
        [Display(Name = "Tiempo Promedio de Preparación:")]
        public Decimal Delivery { get; set; }
        [Display(Name = "Persona Contacto:")]
        public string Contacto { get; set; }
        public bool Activa { get; set; }
        [Column(TypeName = "DateTime2")]
        [Display(Name = "Especialidad:")]
        public int TipodeComida { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }
        [Display(Name = "Archivo de Logo:")]
        public byte[] logo { get; set; }
        public List<GruposMenu> grupomenu { get; set; }
        public List<Menu> menu { get; set; }
        public static List<GruposMenu> GetGrupos()
        {
            List<GruposMenu> grupos = new List<GruposMenu>();
            return grupos;
        }

    }
}
