namespace BookReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Fluent_Api_And_DbSets : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthorBooks", newName: "BookAuthors");
            RenameTable(name: "dbo.GenreBooks", newName: "BookGenres");
            RenameTable(name: "dbo.WishListBooks", newName: "BookWishLists");
            DropForeignKey("dbo.WishLists", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.WishLists", new[] { "User_Id" });
            RenameColumn(table: "dbo.WishLists", name: "User_Id", newName: "UserId");
            DropPrimaryKey("dbo.BookAuthors");
            DropPrimaryKey("dbo.BookGenres");
            DropPrimaryKey("dbo.BookWishLists");
            AlterColumn("dbo.WishLists", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.BookAuthors", new[] { "Book_Id", "Author_Id" });
            AddPrimaryKey("dbo.BookGenres", new[] { "Book_Id", "Genre_Id" });
            AddPrimaryKey("dbo.BookWishLists", new[] { "Book_Id", "WishList_Id" });
            CreateIndex("dbo.WishLists", "UserId");
            AddForeignKey("dbo.WishLists", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.WishLists", "BookReaderUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishLists", "BookReaderUserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.WishLists", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.WishLists", new[] { "UserId" });
            DropPrimaryKey("dbo.BookWishLists");
            DropPrimaryKey("dbo.BookGenres");
            DropPrimaryKey("dbo.BookAuthors");
            AlterColumn("dbo.WishLists", "UserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.BookWishLists", new[] { "WishList_Id", "Book_Id" });
            AddPrimaryKey("dbo.BookGenres", new[] { "Genre_Id", "Book_Id" });
            AddPrimaryKey("dbo.BookAuthors", new[] { "Author_Id", "Book_Id" });
            RenameColumn(table: "dbo.WishLists", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.WishLists", "User_Id");
            AddForeignKey("dbo.WishLists", "User_Id", "dbo.AspNetUsers", "Id");
            RenameTable(name: "dbo.BookWishLists", newName: "WishListBooks");
            RenameTable(name: "dbo.BookGenres", newName: "GenreBooks");
            RenameTable(name: "dbo.BookAuthors", newName: "AuthorBooks");
        }
    }
}
