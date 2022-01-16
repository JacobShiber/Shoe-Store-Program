namespace Mesimat_Sicom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassicShoesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClassicShoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        Gender = c.String(),
                        IsInStock = c.Boolean(nullable: false),
                        HasHeel = c.Boolean(nullable: false),
                        Size = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ClassicShoes");
        }
    }
}
