namespace BookReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Entities_Author_Book_Genre_WishList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Pages = c.Int(nullable: false),
                        Annotation = c.String(),
                        Cover = c.String(),
                        Body = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BookReaderUserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Book_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Book_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.BookApplicationUsers",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.WishListBooks",
                c => new
                    {
                        WishList_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.WishList_Id, t.Book_Id })
                .ForeignKey("dbo.WishLists", t => t.WishList_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.WishList_Id)
                .Index(t => t.Book_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WishLists", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.WishListBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.WishListBooks", "WishList_Id", "dbo.WishLists");
            DropForeignKey("dbo.BookApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.BookApplicationUsers", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Authors");
            DropIndex("dbo.WishListBooks", new[] { "Book_Id" });
            DropIndex("dbo.WishListBooks", new[] { "WishList_Id" });
            DropIndex("dbo.BookApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.BookApplicationUsers", new[] { "Book_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Book_Id" });
            DropIndex("dbo.GenreBooks", new[] { "Genre_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Book_Id" });
            DropIndex("dbo.AuthorBooks", new[] { "Author_Id" });
            DropIndex("dbo.WishLists", new[] { "User_Id" });
            DropTable("dbo.WishListBooks");
            DropTable("dbo.BookApplicationUsers");
            DropTable("dbo.GenreBooks");
            DropTable("dbo.AuthorBooks");
            DropTable("dbo.WishLists");
            DropTable("dbo.Genres");
            DropTable("dbo.Authors");
            DropTable("dbo.Books");
        }
    }
}
