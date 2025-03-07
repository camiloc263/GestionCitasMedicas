namespace CitasMedicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CitaMedica",
                c => new
                    {
                        idcita = c.Int(nullable: false, identity: true),
                        idpaciente = c.Int(),
                        idmedico = c.Int(),
                        lugarcita = c.String(maxLength: 50, unicode: false),
                        fechacita = c.DateTime(storeType: "date"),
                        estadocita = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.idcita);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CitaMedica");
        }
    }
}
