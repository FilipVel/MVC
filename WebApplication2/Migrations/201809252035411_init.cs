namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aranzmen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cena = c.Int(nullable: false),
                        brNok = c.Int(nullable: false),
                        Opis = c.String(),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destinations", t => t.DestinationId, cascadeDelete: true)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aranzmen", "DestinationId", "dbo.Destinations");
            DropIndex("dbo.Aranzmen", new[] { "DestinationId" });
            DropTable("dbo.Destinations");
            DropTable("dbo.Aranzmen");
        }
    }
}
