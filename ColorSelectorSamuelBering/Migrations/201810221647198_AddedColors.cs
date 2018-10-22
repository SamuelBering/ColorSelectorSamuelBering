namespace ColorSelectorSamuelBering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        R = c.Byte(nullable: false),
                        G = c.Byte(nullable: false),
                        B = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Colors");
        }
    }
}
