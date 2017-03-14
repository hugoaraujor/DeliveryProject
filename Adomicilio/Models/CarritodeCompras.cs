using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;

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
        public int Cant { get; set; }
        public Decimal Precio { get; set; }
        public String Mensaje { get; set; }
        public String ingredientes { get; set; }
        public String Extra { get; set; }
        public DateTime Fecha { get; set; }

    }

    public class CarritodeComprasViewModel
    {
        public int id { get; set; }
        public string sessionid { get; set; }
        public string clase { get; set; }
        public int IdProducto { get; set; }
        public int UserId { get; set; }
        public int Cant { get; set; }
        public Decimal Precio { get; set; }
        public String Mensaje { get; set; }
        public String ingredientes { get; set; }
        public String Extra { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEmpresa { get; set; }
        [Display(Name = "Nombre del Negocio")]
        public string RazonSocial { get; set; }
        [Display(Name = "RIF")]
        public string RIF { get; set; }
        [Display(Name = "Producto")]
        public string Nombre { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Imagen")]
        public byte[] imagen { get; set; }
        public String imagenstr
        {
            get {
                String img2 = "../../images/NOPHOTO.png";
                if (imagen != null)
                { 
                    if (imagen.Count() != 0)
                    {
                        MemoryStream ms = new MemoryStream(imagen);
                        //   Image imge = Image.FromStream(ms);

                         img2 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray(), 0, ms.ToArray().Length);
                  
                    }
                    
                }
                return img2;
            }
        }
         
        }
        
    }

