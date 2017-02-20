using Adomicilio.Models;
using System.Web.Mvc;
using System.Web;
namespace Adomicilio.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {  
            ViewBag.Title = "Registro";
            ViewBag.Message = "Your application description page.";
            RegistroUser model = new RegistroUser();
            return View(model);
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegistroUser model)
        {
                       
            if (ModelState.IsValid)
            {


            }
            return View(model);
        }
    }
}