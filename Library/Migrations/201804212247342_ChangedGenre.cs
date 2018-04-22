namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Name", c => c.String());
            DropColumn("dbo.Genres", "DisplayName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "DisplayName", c => c.String());
            DropColumn("dbo.Genres", "Name");
        }
    }
}
