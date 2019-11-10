namespace RegistroCedula.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        Usuario = c.String(nullable: false),
                        Clave = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Cedulas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CedulaID = c.String(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 10),
                        Apellido = c.String(nullable: false, maxLength: 10),
                        LugarNacimiento = c.String(nullable: false, maxLength: 15),
                        FechaNacimiento = c.DateTime(nullable: false),
                        GetNacionalidad = c.Int(nullable: false),
                        GetSexo = c.Int(nullable: false),
                        GetSangre = c.Int(nullable: false),
                        GetEstado = c.Int(nullable: false),
                        Ocupacion = c.String(nullable: false),
                        FechaExp = c.DateTime(nullable: false),
                        Provincia = c.String(nullable: false, maxLength: 15),
                        Municipio = c.String(nullable: false, maxLength: 15),
                        Sector = c.String(nullable: false, maxLength: 15),
                        Colegio = c.String(nullable: false, maxLength: 15),
                        Admin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cedulas");
            DropTable("dbo.Administradors");
        }
    }
}
