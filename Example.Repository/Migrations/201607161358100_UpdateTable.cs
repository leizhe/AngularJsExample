namespace Example.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Role", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "State");
            DropColumn("dbo.User", "CreationTime");
            DropColumn("dbo.Role", "CreationTime");
        }
    }
}
