using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;

namespace Adomicilio.Models
{// New derived classes

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
        {
        public ApplicationDbContext(): base("LocalConnection")
        {
            //hugo araujo r cambio de clave
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            
            // Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
            //  Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());


        }
        public DbSet<Emails> Emails{ get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Valoracion>Valoracion{ get; set; }
        public DbSet<Menu>Menu { get; set; }
         public DbSet<Extras> Extras { get; set; }
        public DbSet<Publicidad> Publicidad { get; set; }
        public DbSet<Category> Categorias { get; set; }
        public DbSet<SubCategorias> SubCategorias { get; set; }
        public DbSet<CarritodeCompras> CarritodeCompras { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<EmpresaSector> EmpresaSector { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado>Estados { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<Ciudad>Ciudades { get; set; }
        public DbSet<General> General { get; set; }
        public DbSet<PreguntasUsuario> PreguntasUsuario { get; set; }
        public DbSet<PreguntasComercio> PreguntasComercio { get; set; }
       public DbSet<Amigo> Invitaciones { get; set; }
        public DbSet<AFiliaciones>Afiliaciones { get; set; }
        public DbSet<Chat>Chat { get; set; }
        public DbSet<Opinion> Opiniones { get; set; }
        public DbSet<Estadistica> Estadistica { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<Sugest> Sugerencias { get; set; }
        public DbSet<TipoEmpresa>  TipoEmpresa { get; set; }
        public DbSet<GruposMenu> GruposMenu { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<MenuIngredients> MenuIngredients { get; set; }
        // public System.Data.Entity.DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contacto> Contactoes { get; set; }

        public object ApplicationUsers { get; internal set; }

        //     public DbSet<Registro> Registro{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //  modelBuilder.Entity<IdentityUserLogin>().HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
            modelBuilder.Entity<Emails>().HasKey<int>(l => l.id);
            
            
        }
    
       

        public static ApplicationDbContext Create()
        {
               return new ApplicationDbContext();
        }

       
    }
}