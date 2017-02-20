namespace Adomicilio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adicionales",
                c => new
                    {
                        IdAdicional = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdAdicional);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        IdCategory = c.Int(nullable: false),
                        IdCategory2 = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Titulo = c.String(),
                        clase1 = c.String(),
                        clase2 = c.String(),
                        clase3 = c.String(),
                        Precio1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        imagenname = c.String(),
                        tiempodepreparacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        nuevo = c.Boolean(nullable: false),
                        Oferta = c.Boolean(nullable: false),
                        imagen = c.Binary(),
                        Activa = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => new { t.IdProducto, t.IdEmpresa })
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategory = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.IdCategory);
            
            CreateTable(
                "dbo.SubCategorias",
                c => new
                    {
                        Subcategory = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        SubCategoryName = c.String(),
                        SubCategoryDesc = c.String(),
                    })
                .PrimaryKey(t => t.Subcategory);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        IdEmpresa = c.Int(nullable: false, identity: true),
                        RazonSocial = c.String(),
                        RIF = c.String(),
                        Telefono = c.String(),
                        Slogan = c.String(),
                        Valoracion = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Celular = c.String(),
                        Direccion = c.String(),
                        Sucursal = c.String(),
                        horario1 = c.String(),
                        horario2 = c.String(),
                        horario3 = c.String(),
                        horario4 = c.String(),
                        horario5 = c.String(),
                        horario6 = c.String(),
                        horario7 = c.String(),
                        Delivery = c.Decimal(nullable: false, precision: 18, scale: 2),
                        logo = c.Binary(),
                        Contacto = c.String(),
                        Activa = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.EmpresaSector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        Sectorid = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa);
            
            CreateTable(
                "dbo.Valoracions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        puntos = c.Int(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .Index(t => t.IdEmpresa)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(),
                        Pais = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Ciudad = c.Int(nullable: false),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        FechaNacimiento = c.DateTime(precision: 7, storeType: "datetime2"),
                        Sexo = c.Int(nullable: false),
                        TipoAfiliacion = c.Int(nullable: false),
                        Created = c.DateTime(precision: 7, storeType: "datetime2"),
                        oldpassword = c.String(),
                        movil = c.String(),
                        aceptapublicidad = c.Boolean(nullable: false),
                        aceptaterminosdeuso = c.Boolean(nullable: false),
                        notificaraltelefonomovil = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        estadistica_EstadisticaId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estadistica", t => t.estadistica_EstadisticaId)
                .Index(t => t.estadistica_EstadisticaId);
            
            CreateTable(
                "dbo.Invitaciones",
                c => new
                    {
                        Idinvite = c.Int(nullable: false, identity: true),
                        UId = c.Int(nullable: false),
                        email = c.String(),
                        Aceptada = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateAccept = c.DateTime(),
                    })
                .PrimaryKey(t => t.Idinvite)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        IdDireccion = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        Calle = c.String(),
                        CasaNro = c.String(),
                        Urbanizacion = c.String(),
                        Municipio = c.String(),
                        zipcode = c.String(),
                        Sector = c.Int(nullable: false),
                        Ciudad = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Pais = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDireccion)
                .ForeignKey("dbo.ApplicationUsers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Estadistica",
                c => new
                    {
                        EstadisticaId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        MontoenCompras = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumerodeCompras = c.Decimal(nullable: false, precision: 18, scale: 2),
                        recomendaciones = c.Int(nullable: false),
                        recomendacionesaceptadas = c.Int(nullable: false),
                        recomendacionesrechazadas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstadisticaId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        UserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        ApplicationUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.MenuIngredients",
                c => new
                    {
                        IdIngrediente = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        Descripcion = c.String(),
                        Requerido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdIngrediente);
            
            CreateTable(
                "dbo.Opiniones",
                c => new
                    {
                        Idopinion = c.Int(nullable: false, identity: true),
                        UId = c.Int(nullable: false),
                        SubId = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        Comentario = c.String(),
                    })
                .PrimaryKey(t => t.Idopinion)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Afiliaciones",
                c => new
                    {
                        afiliaId = c.Int(nullable: false, identity: true),
                        UId = c.Int(nullable: false),
                        Idinvite = c.Int(nullable: false),
                        Aceptada = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.afiliaId)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.CarritodeCompras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrdenNro = c.Long(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Cant = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mensaje = c.String(),
                        ingredientes = c.String(),
                        Extra = c.String(),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateDelivered = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ApplicationUsers", t => t.UserId)
                .ForeignKey("dbo.Ordens", t => t.OrdenNro)
                .Index(t => t.OrdenNro)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Ordens",
                c => new
                    {
                        OrdenNro = c.Long(nullable: false, identity: true),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.OrdenNro);
            
            CreateTable(
                "dbo.Chat",
                c => new
                    {
                        IdChat = c.Int(nullable: false, identity: true),
                        UId = c.Int(nullable: false),
                        Mensaje = c.String(),
                    })
                .PrimaryKey(t => t.IdChat)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        CiudadId = c.Int(nullable: false, identity: true),
                        ciudad = c.String(),
                        IdEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CiudadId);
            
            CreateTable(
                "dbo.Compra",
                c => new
                    {
                        OrdenNro = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        UId = c.Int(nullable: false),
                        IdDireccion = c.Int(nullable: false),
                        idSector = c.Int(nullable: false),
                        tipopago = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrdenNro)
                .ForeignKey("dbo.Direccion", t => t.IdDireccion)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .ForeignKey("dbo.Sector", t => t.idSector)
                .Index(t => t.UId)
                .Index(t => t.IdDireccion)
                .Index(t => t.idSector);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombresector = c.String(),
                        CiudadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contactanos",
                c => new
                    {
                        IdContact = c.Int(nullable: false, identity: true),
                        Telefono = c.String(),
                        Nombre = c.String(),
                        TipodeContacto = c.String(),
                        Descripcion = c.String(),
                        email = c.String(),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateRespondido = c.DateTime(precision: 7, storeType: "datetime2"),
                        DateLeido = c.DateTime(precision: 7, storeType: "datetime2"),
                        respondido = c.Boolean(nullable: false),
                        leido = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdContact);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FromName = c.String(),
                        FromEmail = c.String(),
                        ToName = c.String(),
                        ToEmail = c.String(),
                        Message = c.String(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        Subject = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        IdEstado = c.Int(nullable: false, identity: true),
                        estado = c.String(),
                        IdPais = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEstado);
            
            CreateTable(
                "dbo.General",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdenNro = c.Long(nullable: false),
                        TerminosdeUso = c.String(),
                        Privacidad = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notificaciones",
                c => new
                    {
                        NotifyId = c.Int(nullable: false, identity: true),
                        UId = c.Int(nullable: false),
                        Mensaje = c.String(),
                        vista = c.Boolean(nullable: false),
                        tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotifyId)
                .ForeignKey("dbo.ApplicationUsers", t => t.UId)
                .Index(t => t.UId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        IdPais = c.Int(nullable: false, identity: true),
                        paisName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.IdPais);
            
            CreateTable(
                "dbo.PreguntasComercio",
                c => new
                    {
                        IdPregunta = c.Long(nullable: false, identity: true),
                        Pregunta = c.String(),
                        Respuesta = c.String(),
                    })
                .PrimaryKey(t => t.IdPregunta);
            
            CreateTable(
                "dbo.PreguntasUsuario",
                c => new
                    {
                        IdPregunta = c.Long(nullable: false, identity: true),
                        Pregunta = c.String(),
                        Respuesta = c.String(),
                    })
                .PrimaryKey(t => t.IdPregunta);
            
            CreateTable(
                "dbo.Publicidad",
                c => new
                    {
                        Idpub = c.Int(nullable: false, identity: true),
                        Mensajeenletras = c.String(),
                        Imagenbanner = c.Binary(),
                        Desde = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        HastaFecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        clicks = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Idpub);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sugerencias",
                c => new
                    {
                        IdSugest = c.Int(nullable: false, identity: true),
                        Telefono = c.String(),
                        Contacto = c.String(),
                        Negocio = c.String(),
                        email = c.String(),
                        contraseña = c.String(),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdSugest);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.MenuAdicionales",
                c => new
                    {
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                        Adicionales_IdAdicional = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa, t.Adicionales_IdAdicional })
                .ForeignKey("dbo.Menu", t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .ForeignKey("dbo.Adicionales", t => t.Adicionales_IdAdicional)
                .Index(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .Index(t => t.Adicionales_IdAdicional);
            
            CreateTable(
                "dbo.CategoryMenus",
                c => new
                    {
                        Category_IdCategory = c.Int(nullable: false),
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_IdCategory, t.Menu_IdProducto, t.Menu_IdEmpresa })
                .ForeignKey("dbo.Categorias", t => t.Category_IdCategory)
                .ForeignKey("dbo.Menu", t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .Index(t => t.Category_IdCategory)
                .Index(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa });
            
            CreateTable(
                "dbo.SubCategoriasMenus",
                c => new
                    {
                        SubCategorias_Subcategory = c.Int(nullable: false),
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategorias_Subcategory, t.Menu_IdProducto, t.Menu_IdEmpresa })
                .ForeignKey("dbo.SubCategorias", t => t.SubCategorias_Subcategory)
                .ForeignKey("dbo.Menu", t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .Index(t => t.SubCategorias_Subcategory)
                .Index(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa });
            
            CreateTable(
                "dbo.MenuIngredientsMenus",
                c => new
                    {
                        MenuIngredients_IdIngrediente = c.Int(nullable: false),
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MenuIngredients_IdIngrediente, t.Menu_IdProducto, t.Menu_IdEmpresa })
                .ForeignKey("dbo.MenuIngredients", t => t.MenuIngredients_IdIngrediente)
                .ForeignKey("dbo.Menu", t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .Index(t => t.MenuIngredients_IdIngrediente)
                .Index(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa });
            
            CreateTable(
                "dbo.OpinionMenus",
                c => new
                    {
                        Opinion_Idopinion = c.Int(nullable: false),
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Opinion_Idopinion, t.Menu_IdProducto, t.Menu_IdEmpresa })
                .ForeignKey("dbo.Opiniones", t => t.Opinion_Idopinion)
                .ForeignKey("dbo.Menu", t => new { t.Menu_IdProducto, t.Menu_IdEmpresa })
                .Index(t => t.Opinion_Idopinion)
                .Index(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Notificaciones", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Compra", "idSector", "dbo.Sector");
            DropForeignKey("dbo.Compra", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Compra", "IdDireccion", "dbo.Direccion");
            DropForeignKey("dbo.Chat", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.CarritodeCompras", "OrdenNro", "dbo.Ordens");
            DropForeignKey("dbo.CarritodeCompras", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Afiliaciones", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Opiniones", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.OpinionMenus", "Opinion_Idopinion", "dbo.Opiniones");
            DropForeignKey("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.MenuIngredientsMenus", "MenuIngredients_IdIngrediente", "dbo.MenuIngredients");
            DropForeignKey("dbo.Valoracions", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Valoracions", "UserId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.ApplicationUsers", "estadistica_EstadisticaId", "dbo.Estadistica");
            DropForeignKey("dbo.Direccion", "Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.Invitaciones", "UId", "dbo.ApplicationUsers");
            DropForeignKey("dbo.EmpresaSector", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Menu", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.SubCategoriasMenus", "SubCategorias_Subcategory", "dbo.SubCategorias");
            DropForeignKey("dbo.CategoryMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.CategoryMenus", "Category_IdCategory", "dbo.Categorias");
            DropForeignKey("dbo.MenuAdicionales", "Adicionales_IdAdicional", "dbo.Adicionales");
            DropForeignKey("dbo.MenuAdicionales", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropIndex("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.OpinionMenus", new[] { "Opinion_Idopinion" });
            DropIndex("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.MenuIngredientsMenus", new[] { "MenuIngredients_IdIngrediente" });
            DropIndex("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.SubCategoriasMenus", new[] { "SubCategorias_Subcategory" });
            DropIndex("dbo.CategoryMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.CategoryMenus", new[] { "Category_IdCategory" });
            DropIndex("dbo.MenuAdicionales", new[] { "Adicionales_IdAdicional" });
            DropIndex("dbo.MenuAdicionales", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Notificaciones", new[] { "UId" });
            DropIndex("dbo.Compra", new[] { "idSector" });
            DropIndex("dbo.Compra", new[] { "IdDireccion" });
            DropIndex("dbo.Compra", new[] { "UId" });
            DropIndex("dbo.Chat", new[] { "UId" });
            DropIndex("dbo.CarritodeCompras", new[] { "UserId" });
            DropIndex("dbo.CarritodeCompras", new[] { "OrdenNro" });
            DropIndex("dbo.Afiliaciones", new[] { "UId" });
            DropIndex("dbo.Opiniones", new[] { "UId" });
            DropIndex("dbo.UserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Direccion", new[] { "Id" });
            DropIndex("dbo.UserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Invitaciones", new[] { "UId" });
            DropIndex("dbo.ApplicationUsers", new[] { "estadistica_EstadisticaId" });
            DropIndex("dbo.Valoracions", new[] { "UserId" });
            DropIndex("dbo.Valoracions", new[] { "IdEmpresa" });
            DropIndex("dbo.EmpresaSector", new[] { "IdEmpresa" });
            DropIndex("dbo.Menu", new[] { "IdEmpresa" });
            DropTable("dbo.OpinionMenus");
            DropTable("dbo.MenuIngredientsMenus");
            DropTable("dbo.SubCategoriasMenus");
            DropTable("dbo.CategoryMenus");
            DropTable("dbo.MenuAdicionales");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.Sugerencias");
            DropTable("dbo.Roles");
            DropTable("dbo.Publicidad");
            DropTable("dbo.PreguntasUsuario");
            DropTable("dbo.PreguntasComercio");
            DropTable("dbo.Pais");
            DropTable("dbo.Notificaciones");
            DropTable("dbo.General");
            DropTable("dbo.Estado");
            DropTable("dbo.Emails");
            DropTable("dbo.Contactanos");
            DropTable("dbo.Sector");
            DropTable("dbo.Compra");
            DropTable("dbo.Ciudades");
            DropTable("dbo.Chat");
            DropTable("dbo.Ordens");
            DropTable("dbo.CarritodeCompras");
            DropTable("dbo.Afiliaciones");
            DropTable("dbo.Opiniones");
            DropTable("dbo.MenuIngredients");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Estadistica");
            DropTable("dbo.Direccion");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Invitaciones");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.Valoracions");
            DropTable("dbo.EmpresaSector");
            DropTable("dbo.Empresa");
            DropTable("dbo.SubCategorias");
            DropTable("dbo.Categorias");
            DropTable("dbo.Menu");
            DropTable("dbo.Adicionales");
        }
    }
}
