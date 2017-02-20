using System;
using System.Collections.Generic;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Linq;
using Adomicilio.Controllers;

namespace Adomicilio.Models
{
    public partial class ListHelper
    { 
        public class SelectListItemHelper
        {
            public static IEnumerable<SelectListItem> GetProvincesList()
            {
                IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "California", Value = "1"},
                new SelectListItem{Text = "Alaska", Value = "2"},
                new SelectListItem{Text = "Illinois", Value = "3"},
                new SelectListItem{Text = "Texas",  Value = "4"},
                new SelectListItem{Text = "Washington", Value = "5"}

            };
                return items;
            }
            public static IEnumerable<SelectListItem> GetEstadosList(int idpais)
            {
                EstadosController ec = new EstadosController();
                var query = ec.GetEstadosPaisId(idpais);
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.estado, Value = e.IdEstado.ToString() });
                };
                return items;
            }
            public static IEnumerable<SelectListItem> GetSectoresList(int idcity)
            {
                SectorsController ec = new SectorsController();
                var query = ec.GetSectoresList(idcity);
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.Nombresector, Value = e.Id.ToString() });
                };
                return items;
            }
            public static IEnumerable<SelectListItem> GetCiudadesList(int idestado)
            {
                CiudadesController ec = new CiudadesController();
                var query = ec.GetCiudadesList(idestado);
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.ciudad, Value = e.CiudadId.ToString() });
                };
               // items.Add(new SelectListItem { Text = "Ningun"+idestado.ToString(), Value = "88" });
                return items;
            }
            public static IEnumerable<SelectListItem> GetCategoriasempresa()
            {
               TipoEmpresasController ec = new TipoEmpresasController();
                 var query = ec.GetTipos();
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.TipodeLocal, Value = e.Id.ToString() });
                };
                // items.Add(new SelectListItem { Text = "Ningun"+idestado.ToString(), Value = "88" });
                return items;
            }
            public static IEnumerable<SelectListItem> GetGruposMenu(int idempresa)
            {
                GruposMenusController ec = new GruposMenusController();
                var query=ec.getgrupos(idempresa);
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.GrupoMenuDesc, Value = e.Id.ToString()});
                };
            return items;
            }
            public static IEnumerable<SelectListItem> Getespecialidades()
            {
                EspecialidadesController ec = new EspecialidadesController();
                var query = ec.getespecialidades();
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text =e.EspecialidadDesc,Value = e.IdEspecialidad.ToString() });
                };
            return items;
            }
            public static IEnumerable<SelectListItem> GetCategorias()
            {
               CategoriesController ec = new CategoriesController();
                var query = ec.getcategoriasproductos();
                IList<SelectListItem> items = new List<SelectListItem>();
                foreach (var e in query)
                {
                    items.Add(new SelectListItem { Text = e.CategoryName, Value = e.IdCategory.ToString() });
                };
                return items;
            }

        }
    }
 }
