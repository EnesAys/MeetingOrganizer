namespace MeetingOrganizer.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Katilimcis", "Ad", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Katilimcis", "Soyad", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Toplantis", "Konu", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Toplantis", "Konu", c => c.String());
            AlterColumn("dbo.Katilimcis", "Soyad", c => c.String());
            AlterColumn("dbo.Katilimcis", "Ad", c => c.String());
        }
    }
}
