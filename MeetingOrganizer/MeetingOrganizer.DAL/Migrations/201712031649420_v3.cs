namespace MeetingOrganizer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Katilimcis", "ToplantiID", "dbo.Toplantis");
            DropIndex("dbo.Katilimcis", new[] { "ToplantiID" });
            AlterColumn("dbo.Katilimcis", "ToplantiID", c => c.Int());
            CreateIndex("dbo.Katilimcis", "ToplantiID");
            AddForeignKey("dbo.Katilimcis", "ToplantiID", "dbo.Toplantis", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Katilimcis", "ToplantiID", "dbo.Toplantis");
            DropIndex("dbo.Katilimcis", new[] { "ToplantiID" });
            AlterColumn("dbo.Katilimcis", "ToplantiID", c => c.Int(nullable: false));
            CreateIndex("dbo.Katilimcis", "ToplantiID");
            AddForeignKey("dbo.Katilimcis", "ToplantiID", "dbo.Toplantis", "ID", cascadeDelete: true);
        }
    }
}
