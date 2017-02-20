using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Adomicilio.Models;
namespace Adomicilio.Controllers
{
    public class HomeController : Controller
    {
        IndexViewModel ivm = new IndexViewModel();

        public ActionResult Index()
        {

            PaisController PaisCntlr = new PaisController();
            ApplicationDbContext context = new ApplicationDbContext();
            AccountController ac = new AccountController();
            Console.WriteLine(ac.HashPassword("V-1234567"));
            var AUX = ac.HashPassword("V-1234567");
            int n = context.Paises.Count<Pais>();
            if (n == 0)
            {
                //     PaisCntlr.Create(new Pais { paisName = "Venezuela" });
                EstadosController StatesCntlr = new EstadosController();
                CiudadesController CiudadesCtrller = new CiudadesController();
                SectorsController SectorCtrller = new SectorsController();
                string[] arr1 = new string[] { "Amazonas", "Anzoategui", "Apure", "Aragua", "Barinas", "Bolivar", "Carabobo", "Cojedes", "Delta Amacuro", "Falcón", "Guarico", "Lara", "Mérida", "Miranda", "Monagas", "Nueva Esparta", "Portuguesa", "Sucre", "Tachira", "Trujillo", "Vargas", "Yaracuy", "Zulia", "Distrito Capital" };
                string[] arr2 = new string[] { "Bachaquero", "Cabimas", "Ciudad Ojeda", "Salinas", "Machiques", "Maracaibo", "Santa Barbara", "Villa del Rosario", "Mene Grande", "Altagracia", "Guayabo", "La Cañada" };
                string[] arr3 = new string[] { "Casco Central", "Las Morochas", "Andres Eloy Blanco I", "Andres Eloy Blanco II", "Barrio Libertad", "Rafael Urdaneta", "San Jose", "1ero de Mayo", "Barrio Simón Bolivar", "Nueva Venezuela", "Nueva Lagunillas", "Barrio Obrero", "Campo ELias", "Las Playitas", "Barrio Nuevo", "San Agustin", "Elezar Lopez COntreras", "1ero de Mayo", "Costa Mar", "Inamar", "Los Samanes", "Zona Industrial", "Barrio Union", "Jose Feliz Rivas", "Tia Juana", "Tamare", "Campo Mio", "Lagunillas", "El Danto" };

                Array.Sort(arr1, StringComparer.InvariantCulture);
                Array.Sort(arr2, StringComparer.InvariantCulture);
                Array.Sort(arr3, StringComparer.InvariantCulture);
                foreach (var state in arr1)
                {
                    StatesCntlr.Create(new Estado { IdPais = 1, estado = state });
                }
                foreach (var citndx in arr2)
                {
                   CiudadesCtrller.Create(new Ciudad { ciudad = citndx, IdEstado = 24 });
                }
                foreach (var secndx in arr3)
                {
                    SectorCtrller.Create(new Sector { Nombresector = secndx, CiudadId = 4 });
                }


                PaisCntlr.Create(new Pais { paisName = "Venezuela" });


                context.Roles.Add(new Role { Id = 1, Name = "User" });
                context.Roles.Add(new Role { Id = 2, Name = "Admin" });
                context.Users.Add(new ApplicationUser { UserName = "admin@adomicilio.com", Email = "admin@adomicilio.com", Password = "V-1234567", EmailConfirmed = true, TipoAfiliacion = 0, Sexo = Sexoenum.Masculino, Apellidos = "administrador", PasswordHash = "AF7gxVvymbfhUC2kVhlCsMnIInByOBvX16YbkTehqdyViYOaQ3iDUm1HLJjwgA / Qig ==", SecurityStamp = "41a72c89-adce-4a53-9644-85e46dc473c7", Nombres = "administrador", Pais = 1, Ciudad = 1 });
                try
                {
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);

                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                            Console.WriteLine(message);
                        }
                    }
                    throw raise;
                }
                context.SaveChanges();
            }
            ivm.Pais = 1;
            return View(ivm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Detail()
        {
            IndexViewModel ivm = new IndexViewModel();
            ViewBag.Message = "Detalle de Restaurant.";

            return View(ivm);
        }

    }
}