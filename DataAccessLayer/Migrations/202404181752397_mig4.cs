namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Autors", "AutorTitle", c => c.String(maxLength: 50));
            AddColumn("dbo.Autors", "AutorAboutShort", c => c.String(maxLength: 100));
            AddColumn("dbo.Autors", "AutorMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Autors", "AutorPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Autors", "AutorPhoneNumber", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Autors", "AutorPhoneNumber");
            DropColumn("dbo.Autors", "AutorPassword");
            DropColumn("dbo.Autors", "AutorMail");
            DropColumn("dbo.Autors", "AutorAboutShort");
            DropColumn("dbo.Autors", "AutorTitle");
        }
    }
}
