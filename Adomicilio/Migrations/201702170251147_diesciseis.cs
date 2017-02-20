namespace Adomicilio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diesciseis : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuCategories", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.MenuCategories", "Category_IdCategory", "dbo.Categorias");
            DropForeignKey("dbo.SubCategoriasMenus", "SubCategorias_Subcategory", "dbo.SubCategorias");
            DropForeignKey("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.ExtrasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropForeignKey("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu");
            DropIndex("dbo.MenuCategories", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.MenuCategories", new[] { "Category_IdCategory" });
            DropIndex("dbo.SubCategoriasMenus", new[] { "SubCategorias_Subcategory" });
            DropIndex("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.ExtrasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropIndex("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            DropPrimaryKey("dbo.Menu");
            DropPrimaryKey("dbo.ExtrasMenus");
            DropPrimaryKey("dbo.MenuIngredientsMenus");
            DropPrimaryKey("dbo.OpinionMenus");
            CreateTable(
                "dbo.Contactanos",
                c => new
                    {
                        IdContact = c.Int(nullable: false, identity: true),
                        Telefono = c.String(),
                        Nombre = c.String(nullable: false),
                        TipodeContacto = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false),
                        email = c.String(nullable: false),
                        DateCreated = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.IdContact);
            
            CreateTable(
                "dbo.Especialidad",
                c => new
                    {
                        IdEspecialidad = c.Int(nullable: false, identity: true),
                        EspecialidadDesc = c.String(),
                    })
                .PrimaryKey(t => t.IdEspecialidad);
            
            CreateTable(
                "dbo.GruposMenu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEmpresa = c.Int(nullable: false),
                        GrupoMenuDesc = c.String(),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoEmpresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TipodeLocal = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menu", "IdGrupoMenu", c => c.Int(nullable: false));
            AddColumn("dbo.Menu", "IdSubCategorias", c => c.Int(nullable: false));
            AddColumn("dbo.SubCategorias", "IdCategory", c => c.Int(nullable: false));
            AddColumn("dbo.Empresa", "Telefonos", c => c.String());
            AddColumn("dbo.Empresa", "CategoriaLocal", c => c.Int(nullable: false));
            AddColumn("dbo.Empresa", "TipodeComida", c => c.Int(nullable: false));
            AddColumn("dbo.Empresa", "like", c => c.Int(nullable: false));
            AlterColumn("dbo.Empresa", "Delivery", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Menu", "IdProducto");
            AddPrimaryKey("dbo.ExtrasMenus", new[] { "Extras_IdAdicional", "Menu_IdProducto" });
            AddPrimaryKey("dbo.MenuIngredientsMenus", new[] { "MenuIngredients_IdIngrediente", "Menu_IdProducto" });
            AddPrimaryKey("dbo.OpinionMenus", new[] { "Opinion_Idopinion", "Menu_IdProducto" });
            CreateIndex("dbo.ExtrasMenus", "Menu_IdProducto");
            CreateIndex("dbo.MenuIngredientsMenus", "Menu_IdProducto");
            CreateIndex("dbo.OpinionMenus", "Menu_IdProducto");
            AddForeignKey("dbo.ExtrasMenus", "Menu_IdProducto", "dbo.Menu", "IdProducto");
            AddForeignKey("dbo.MenuIngredientsMenus", "Menu_IdProducto", "dbo.Menu", "IdProducto");
            AddForeignKey("dbo.OpinionMenus", "Menu_IdProducto", "dbo.Menu", "IdProducto");
            DropColumn("dbo.Menu", "IdCategory2");
            DropColumn("dbo.Menu", "tiempodepreparacion");
            DropColumn("dbo.SubCategorias", "IdEmpresa");
            DropColumn("dbo.SubCategorias", "SubCategoryDesc");
            DropColumn("dbo.Empresa", "Telefono");
            DropColumn("dbo.Empresa", "Tipo");
            DropColumn("dbo.Empresa", "Celular");
            DropColumn("dbo.Empresa", "Sucursal");
            DropColumn("dbo.Empresa", "horario2");
            DropColumn("dbo.Empresa", "horario3");
            DropColumn("dbo.Empresa", "horario4");
            DropColumn("dbo.Empresa", "horario5");
            DropColumn("dbo.Empresa", "horario6");
            DropColumn("dbo.Empresa", "horario7");
            DropColumn("dbo.ExtrasMenus", "Menu_IdEmpresa");
            DropColumn("dbo.MenuIngredientsMenus", "Menu_IdEmpresa");
            DropColumn("dbo.OpinionMenus", "Menu_IdEmpresa");
            DropTable("dbo.MenuCategories");
            DropTable("dbo.SubCategoriasMenus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubCategoriasMenus",
                c => new
                    {
                        SubCategorias_Subcategory = c.Int(nullable: false),
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SubCategorias_Subcategory, t.Menu_IdProducto, t.Menu_IdEmpresa });
            
            CreateTable(
                "dbo.MenuCategories",
                c => new
                    {
                        Menu_IdProducto = c.Int(nullable: false),
                        Menu_IdEmpresa = c.Int(nullable: false),
                        Category_IdCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_IdProducto, t.Menu_IdEmpresa, t.Category_IdCategory });
            
            AddColumn("dbo.OpinionMenus", "Menu_IdEmpresa", c => c.Int(nullable: false));
            AddColumn("dbo.MenuIngredientsMenus", "Menu_IdEmpresa", c => c.Int(nullable: false));
            AddColumn("dbo.ExtrasMenus", "Menu_IdEmpresa", c => c.Int(nullable: false));
            AddColumn("dbo.Empresa", "horario7", c => c.String());
            AddColumn("dbo.Empresa", "horario6", c => c.String());
            AddColumn("dbo.Empresa", "horario5", c => c.String());
            AddColumn("dbo.Empresa", "horario4", c => c.String());
            AddColumn("dbo.Empresa", "horario3", c => c.String());
            AddColumn("dbo.Empresa", "horario2", c => c.String());
            AddColumn("dbo.Empresa", "Sucursal", c => c.String());
            AddColumn("dbo.Empresa", "Celular", c => c.String());
            AddColumn("dbo.Empresa", "Tipo", c => c.Int(nullable: false));
            AddColumn("dbo.Empresa", "Telefono", c => c.String());
            AddColumn("dbo.SubCategorias", "SubCategoryDesc", c => c.String());
            AddColumn("dbo.SubCategorias", "IdEmpresa", c => c.Int(nullable: false));
            AddColumn("dbo.Menu", "tiempodepreparacion", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Menu", "IdCategory2", c => c.Int(nullable: false));
            DropForeignKey("dbo.OpinionMenus", "Menu_IdProducto", "dbo.Menu");
            DropForeignKey("dbo.MenuIngredientsMenus", "Menu_IdProducto", "dbo.Menu");
            DropForeignKey("dbo.ExtrasMenus", "Menu_IdProducto", "dbo.Menu");
            DropIndex("dbo.OpinionMenus", new[] { "Menu_IdProducto" });
            DropIndex("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto" });
            DropIndex("dbo.ExtrasMenus", new[] { "Menu_IdProducto" });
            DropPrimaryKey("dbo.OpinionMenus");
            DropPrimaryKey("dbo.MenuIngredientsMenus");
            DropPrimaryKey("dbo.ExtrasMenus");
            DropPrimaryKey("dbo.Menu");
            AlterColumn("dbo.Empresa", "Delivery", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Empresa", "like");
            DropColumn("dbo.Empresa", "TipodeComida");
            DropColumn("dbo.Empresa", "CategoriaLocal");
            DropColumn("dbo.Empresa", "Telefonos");
            DropColumn("dbo.SubCategorias", "IdCategory");
            DropColumn("dbo.Menu", "IdSubCategorias");
            DropColumn("dbo.Menu", "IdGrupoMenu");
            DropTable("dbo.TipoEmpresa");
            DropTable("dbo.GruposMenu");
            DropTable("dbo.Especialidad");
            DropTable("dbo.Contactanos");
            AddPrimaryKey("dbo.OpinionMenus", new[] { "Opinion_Idopinion", "Menu_IdProducto", "Menu_IdEmpresa" });
            AddPrimaryKey("dbo.MenuIngredientsMenus", new[] { "MenuIngredients_IdIngrediente", "Menu_IdProducto", "Menu_IdEmpresa" });
            AddPrimaryKey("dbo.ExtrasMenus", new[] { "Extras_IdAdicional", "Menu_IdProducto", "Menu_IdEmpresa" });
            AddPrimaryKey("dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
            CreateIndex("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            CreateIndex("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            CreateIndex("dbo.ExtrasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            CreateIndex("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            CreateIndex("dbo.SubCategoriasMenus", "SubCategorias_Subcategory");
            CreateIndex("dbo.MenuCategories", "Category_IdCategory");
            CreateIndex("dbo.MenuCategories", new[] { "Menu_IdProducto", "Menu_IdEmpresa" });
            AddForeignKey("dbo.OpinionMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
            AddForeignKey("dbo.MenuIngredientsMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
            AddForeignKey("dbo.ExtrasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
            AddForeignKey("dbo.SubCategoriasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
            AddForeignKey("dbo.SubCategoriasMenus", "SubCategorias_Subcategory", "dbo.SubCategorias", "Subcategory");
            AddForeignKey("dbo.MenuCategories", "Category_IdCategory", "dbo.Categorias", "IdCategory");
            AddForeignKey("dbo.MenuCategories", new[] { "Menu_IdProducto", "Menu_IdEmpresa" }, "dbo.Menu", new[] { "IdProducto", "IdEmpresa" });
        }
    }
}
