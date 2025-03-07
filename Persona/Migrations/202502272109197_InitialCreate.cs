namespace Persona.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Personas", newName: "ListaPersona");
            AlterColumn("dbo.ListaPersona", "tipoDocumento", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ListaPersona", "nombre", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.ListaPersona", "apellidoUno", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.ListaPersona", "apellidoDos", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.ListaPersona", "direccion", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.ListaPersona", "telefono", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.ListaPersona", "correo", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListaPersona", "correo", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ListaPersona", "telefono", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ListaPersona", "direccion", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.ListaPersona", "apellidoDos", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ListaPersona", "apellidoUno", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.ListaPersona", "nombre", c => c.String(maxLength: 40, unicode: false));
            AlterColumn("dbo.ListaPersona", "tipoDocumento", c => c.String(nullable: false, maxLength: 20, unicode: false));
            RenameTable(name: "dbo.ListaPersona", newName: "Personas");
        }
    }
}
