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
                        ID = c.Guid(nullable: false),
                        Image = c.Binary(nullable: false),
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
                        Admin_AdminID = c.Int(),
                        ColegioID_ColegioID = c.Int(nullable: false),
                        MunicipioID_MunicipioID = c.Int(nullable: false),
                        ProvinciaID_ProvinciaID = c.Int(nullable: false),
                        SectorID_SectorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Administradors", t => t.Admin_AdminID)
                .ForeignKey("dbo.Colegios", t => t.ColegioID_ColegioID, cascadeDelete: true)
                .ForeignKey("dbo.Municipios", t => t.MunicipioID_MunicipioID, cascadeDelete: true)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaID_ProvinciaID, cascadeDelete: true)
                .ForeignKey("dbo.Sectors", t => t.SectorID_SectorID, cascadeDelete: true)
                .Index(t => t.Admin_AdminID)
                .Index(t => t.ColegioID_ColegioID)
                .Index(t => t.MunicipioID_MunicipioID)
                .Index(t => t.ProvinciaID_ProvinciaID)
                .Index(t => t.SectorID_SectorID);
            
            CreateTable(
                "dbo.Colegios",
                c => new
                    {
                        ColegioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        GetSector_SectorID = c.Int(),
                    })
                .PrimaryKey(t => t.ColegioID)
                .ForeignKey("dbo.Sectors", t => t.GetSector_SectorID)
                .Index(t => t.GetSector_SectorID);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        SectorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        GetMunicipio_MunicipioID = c.Int(),
                    })
                .PrimaryKey(t => t.SectorID)
                .ForeignKey("dbo.Municipios", t => t.GetMunicipio_MunicipioID)
                .Index(t => t.GetMunicipio_MunicipioID);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        MunicipioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        GetProvincia_ProvinciaID = c.Int(),
                    })
                .PrimaryKey(t => t.MunicipioID)
                .ForeignKey("dbo.Provincias", t => t.GetProvincia_ProvinciaID)
                .Index(t => t.GetProvincia_ProvinciaID);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cedulas", "SectorID_SectorID", "dbo.Sectors");
            DropForeignKey("dbo.Cedulas", "ProvinciaID_ProvinciaID", "dbo.Provincias");
            DropForeignKey("dbo.Cedulas", "MunicipioID_MunicipioID", "dbo.Municipios");
            DropForeignKey("dbo.Cedulas", "ColegioID_ColegioID", "dbo.Colegios");
            DropForeignKey("dbo.Colegios", "GetSector_SectorID", "dbo.Sectors");
            DropForeignKey("dbo.Sectors", "GetMunicipio_MunicipioID", "dbo.Municipios");
            DropForeignKey("dbo.Municipios", "GetProvincia_ProvinciaID", "dbo.Provincias");
            DropForeignKey("dbo.Cedulas", "Admin_AdminID", "dbo.Administradors");
            DropIndex("dbo.Municipios", new[] { "GetProvincia_ProvinciaID" });
            DropIndex("dbo.Sectors", new[] { "GetMunicipio_MunicipioID" });
            DropIndex("dbo.Colegios", new[] { "GetSector_SectorID" });
            DropIndex("dbo.Cedulas", new[] { "SectorID_SectorID" });
            DropIndex("dbo.Cedulas", new[] { "ProvinciaID_ProvinciaID" });
            DropIndex("dbo.Cedulas", new[] { "MunicipioID_MunicipioID" });
            DropIndex("dbo.Cedulas", new[] { "ColegioID_ColegioID" });
            DropIndex("dbo.Cedulas", new[] { "Admin_AdminID" });
            DropTable("dbo.Provincias");
            DropTable("dbo.Municipios");
            DropTable("dbo.Sectors");
            DropTable("dbo.Colegios");
            DropTable("dbo.Cedulas");
            DropTable("dbo.Administradors");
        }
    }
}
