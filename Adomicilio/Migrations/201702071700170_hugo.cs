namespace Adomicilio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hugo : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Adicionales", newName: "Extras");
            RenameTable(name: "dbo.CategoryMenus", newName: "MenuCategories");
            RenameTable(name: "dbo.MenuAdicionales", newName: "ExtrasMenus");
            RenameColumn(table: "dbo.ExtrasMenus", name: "Adicionales_IdAdicional", newName: "Extras_IdAdicional");
            RenameIndex(table: "dbo.ExtrasMenus", name: "IX_Adicionales_IdAdicional", newName: "IX_Extras_IdAdicional");
            DropPrimaryKey("dbo.MenuCategories");
            DropPrimaryKey("dbo.ExtrasMenus");
            AddPrimaryKey("dbo.MenuCategories", new[] { "Menu_IdProducto", "Menu_IdEmpresa", "Category_IdCategory" });
            AddPrimaryKey("dbo.ExtrasMenus", new[] { "Extras_IdAdicional", "Menu_IdProducto", "Menu_IdEmpresa" });
            DropTable("dbo.Contactanos");
        }
        
        public override void Down()
        {
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
            
            DropPrimaryKey("dbo.ExtrasMenus");
            DropPrimaryKey("dbo.MenuCategories");
            AddPrimaryKey("dbo.ExtrasMenus", new[] { "Menu_IdProducto", "Menu_IdEmpresa", "Adicionales_IdAdicional" });
            AddPrimaryKey("dbo.MenuCategories", new[] { "Category_IdCategory", "Menu_IdProducto", "Menu_IdEmpresa" });
            RenameIndex(table: "dbo.ExtrasMenus", name: "IX_Extras_IdAdicional", newName: "IX_Adicionales_IdAdicional");
            RenameColumn(table: "dbo.ExtrasMenus", name: "Extras_IdAdicional", newName: "Adicionales_IdAdicional");
            RenameTable(name: "dbo.ExtrasMenus", newName: "MenuAdicionales");
            RenameTable(name: "dbo.MenuCategories", newName: "CategoryMenus");
            RenameTable(name: "dbo.Extras", newName: "Adicionales");
        }
    }
}
