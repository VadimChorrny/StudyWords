namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setbooleanvariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "IsKnow", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "IsKnow");
        }
    }
}
