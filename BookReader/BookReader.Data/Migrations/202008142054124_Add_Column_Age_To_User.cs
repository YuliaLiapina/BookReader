namespace BookReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_Age_To_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
