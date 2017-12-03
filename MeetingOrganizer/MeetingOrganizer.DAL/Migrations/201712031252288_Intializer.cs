namespace MeetingOrganizer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Katilimcis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        ToplantiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Toplantis", t => t.ToplantiID, cascadeDelete: true)
                .Index(t => t.ToplantiID);
            
            CreateTable(
                "dbo.Toplantis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Konu = c.String(),
                        T_Tarih = c.DateTime(nullable: false),
                        BaslangicSaat = c.DateTime(nullable: false),
                        BitisSaat = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Katilimcis", "ToplantiID", "dbo.Toplantis");
            DropIndex("dbo.Katilimcis", new[] { "ToplantiID" });
            DropTable("dbo.Toplantis");
            DropTable("dbo.Katilimcis");
        }
    }
}
