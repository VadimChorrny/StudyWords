namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Words", "GroupId", "dbo.Groups");
            DropIndex("dbo.Words", new[] { "GroupId" });
            DropColumn("dbo.Words", "GroupId");
            DropTable("dbo.Groups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CardCounter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Words", "GroupId", c => c.Int());
            CreateIndex("dbo.Words", "GroupId");
            AddForeignKey("dbo.Words", "GroupId", "dbo.Groups", "Id");
        }
    }
}
