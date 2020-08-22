namespace BookReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Column_RegistrationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RegistrationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "RegistrationDate");
        }
    }
}
