using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Linq;

namespace Adomicilio.Models
{// New derived classes
    public class UserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }

    public class UserClaim : IdentityUserClaim<int>
    {
        
    }

    public class UserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }

    public class UserStore : UserStore<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        public UserStore(ApplicationDbContext context) : base(context)
        {
        }

        internal void AddLoginAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(ApplicationDbContext context) : base(context)
        {
        }
    }
    //  public class ApplicationUser : IdentityUser<int>
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, UserLogin, UserRole, UserClaim>
    {
        public ApplicationUser()
        {

            //  Created = DataExtension.MinValue();
        }

        [Required]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
           "No se aceptan numeros o caracteres especiales en el nombre.")]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Pais { get; set; }
        public int Estado { get; set; }
        public int Ciudad { get; set; }
        
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? FechaNacimiento { get; set; }
        public Sexoenum Sexo { get; set; }
        public TipoAfiliacion TipoAfiliacion { get; set; }
        [Column(TypeName = "DateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Created { get; set; }
        public string oldpassword { get; set; }
        public string movil { get; set; }
        public bool aceptapublicidad { get; set; }
        public bool aceptaterminosdeuso { get; set; }
        public bool notificaraltelefonomovil { get; set; }
        public virtual Estadistica estadistica { get; set; }
        public virtual List<Direccion> Direcciones { get; set; }
        public virtual List<Amigo> Amigos { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }
}