using Adomicilio.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Adomicilio.Models
{
    [Table("Menu")]
    public class Menu
    {
        public Menu()
        {
            //  DateCreated = DataExtension.MinValue();
              }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Código")]
        public int IdProducto { get; set; }
        [Display(Name = "Empresa")]
        public int IdEmpresa { get; set; }
        [Display(Name = "Renglón")]
        public int IdGrupoMenu { get; set; }
        [Display(Name = "Clase")]
        public int IdCategory { get; set; }
        [Display(Name = "Categoria")]
        public int IdSubCategorias { get; set; }
        [Display(Name = "Producto")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "TAGS")]
        public string Titulo { get; set; }
        [Display(Name = "Presentación")]
        public string clase1 { get; set; }
        [Display(Name = "Presentación")]
        public string clase2 { get; set; }
        [Display(Name = "Presentación")]
        public string clase3 { get; set; }
        [Display(Name = "Precio Bs.")]
        //    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#0.00}")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Precio invalido use puntos como signo de decimal y dos decimales.")]
        public Decimal Precio1 { get; set; }
        [Display(Name = "Precio Bs.")]
           [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Precio invalido use puntos como signo de decimal y dos decimales.")]
      //  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#0.00}")]
        public Decimal Precio2 { get; set; }
          [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Precio invalido use puntos como signo de decimal y dos decimales.")]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#0.00}")]
        [Display(Name = "Precio Bs.")]
        public Decimal Precio3 { get; set; }
        [Display(Name = "Archivo")]
        public string imagenname { get; set; }
        [Display(Name = "Nuevo")]
        public bool nuevo { get; set; }
        [Display(Name = "Oferta")]
        public bool Oferta { get; set; }
        [Display(Name = "Imagen")]
        public byte[] imagen { get; set; }
        [Display(Name = "Activa")]
        public bool Activa { get; set; }
         [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DateCreated { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<MenuIngredients> Ingredientes { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<Extras> extras { get; set; }
        [ForeignKey("IdProducto")]
        public virtual List<Opinion> Opiniones { get; set; }
        [Display(Name = "Ingredientes")]
        public string SelecciondeIngredientes { get; set; }
        [Display(Name = "Extras")]
        public string SelecciondeExtras { get; set; }

        public List<MenuIngredients>  Getingredientes(int idproducto)
    {
            MenuIngredientsController mic = new MenuIngredientsController();
            var query= mic.Getingredientes(idproducto);
            return query;
    }
    public List<Extras> GetExtras(int idproducto)
    {
            ExtrasController exc = new ExtrasController();
            var query = exc.GetExtras(idproducto);
            return query;
        }
    }

}
