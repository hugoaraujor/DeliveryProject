using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Adomicilio.Models;
using PagedList;
using System.Web;
using System;

namespace Adomicilio.Models
{
    
    public class IndexViewModel
    {
       
        public IndexViewModel()
            {
            ListaEspecialidades = new List<Especialidad>();
            utiles = new UtilesViews();

            page = 1;
            }
        public string Searchstr { get; set; }
        public int ciudad { get; set; }
        public int page { get; set; }
        public int menuopcion { get; set; }
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        public List<Especialidad> ListaEspecialidades { get; set; }
        public UtilesViews utiles { get; set; }
        public PagedList.IPagedList<Empresa> restaurante { get; set; }
        public List<GruposMenu> opcionesmenu { get; set; }
        public List<Menu> PLatos { get; set; }
       public Contacto contact { get; set; }
        public bool iscontact { get; set; }
        public bool added { get; set; }
        public string userid { get; set; }
        public string username { get; set; }
        public bool loggedin { get; set; }
        public Empresa CurrentEmpresa { get; set; }
        public int primergrupo { get; set; }


    }
   
    public class Searchlocation
    {
        public string ip { get; set; }
        public int Pais { get; set; }
        public int Sector { get; set; }
        public int Estado { get; set; }
        public int Ciudad { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la contraseña nueva")]
        [Compare("NewPassword", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña nueva")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme la contraseña nueva")]
        [Compare("NewPassword", ErrorMessage = "La contraseña nueva y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número de teléfono")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Número de teléfono")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}