using Autofac;
using AutoMapper;
using BookReader.Data.Models;
using BookReader.Models;
using BookReader.Models.Author;
using BookReader.Models.Book;
using BookReader.Models.Genre;
using BookReader.Models.WishList;
using BookReaderManager.Business.Models;

namespace BookReader.Autofac
{
    public class MapperAutofacModul:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookModel>();
                cfg.CreateMap<BookModel, Book>();
                cfg.CreateMap<BookModel, BookViewModel>();
                cfg.CreateMap<BookViewModel, BookModel>();

                cfg.CreateMap<Author, AuthorModel>();
                cfg.CreateMap<AuthorModel, Author>();
                cfg.CreateMap<AuthorModel, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, AuthorModel>();

                cfg.CreateMap<Genre, GenreModel>();
                cfg.CreateMap<GenreModel, Genre>();
                cfg.CreateMap<GenreModel, GenreViewModel>();
                cfg.CreateMap<GenreViewModel, GenreModel>();

                cfg.CreateMap<WishList, WishListModel>();
                cfg.CreateMap<WishListModel, WishList>();
                cfg.CreateMap<WishListModel, WishListViewModel>();
                cfg.CreateMap<WishListViewModel, WishListModel>();

                cfg.CreateMap<ApplicationUser, ApplicationUserModel>();
                cfg.CreateMap<ApplicationUserModel, ApplicationUser>();
                cfg.CreateMap<ApplicationUserModel, ApplicationUserViewModel>();
                cfg.CreateMap<ApplicationUserViewModel, ApplicationUserModel>();

                cfg.CreateMap<ApplicationUserModel, EditUserPostModel>();
                cfg.CreateMap<EditUserPostModel, ApplicationUserModel>();

                cfg.CreateMap<BookModel, CreateBookPostModel>();
                cfg.CreateMap<CreateBookPostModel, BookModel>();

                cfg.CreateMap<EditBookPostModel, BookModel>();
                cfg.CreateMap<BookModel, EditBookPostModel>();

                cfg.CreateMap<CreateGenrePostModel, GenreModel>();
                cfg.CreateMap<GenreModel, CreateGenrePostModel>();

                cfg.CreateMap<EditGenrePostModel, GenreViewModel>();
                cfg.CreateMap<GenreViewModel, EditGenrePostModel>();

                cfg.CreateMap<EditGenrePostModel, GenreModel>();
                cfg.CreateMap<GenreModel, EditGenrePostModel>();

                cfg.CreateMap<EditAuthorPostModel, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, EditAuthorPostModel>();

                cfg.CreateMap<EditAuthorPostModel, AuthorModel>();
                cfg.CreateMap<AuthorModel, EditAuthorPostModel>();

                cfg.CreateMap<CreateAuthorPostModel, AuthorModel>();
                cfg.CreateMap<AuthorModel, CreateAuthorPostModel>();

                cfg.CreateMap<EditUserPostModel, ApplicationUserModel>();
                cfg.CreateMap<ApplicationUserModel, EditUserPostModel>();

                cfg.CreateMap<CreateWishListPostModel, WishListModel>();
                cfg.CreateMap<WishListModel, CreateWishListPostModel>();

                cfg.CreateMap<WishListModel, EditWishListPostModel>();
                cfg.CreateMap<EditWishListPostModel, WishListModel>();

                cfg.CreateMap<BookViewModel, BookDetailsViewModel>();
                cfg.CreateMap<BookDetailsViewModel, BookViewModel>();

                cfg.CreateMap<BookModel, ReedBookViewModel>();
                cfg.CreateMap<ReedBookViewModel, BookModel>();

                cfg.CreateMap<BookModel, BookPostModel>();
                cfg.CreateMap<BookPostModel, BookModel>();

                cfg.CreateMap<AuthorModel, AuthorPostModel>();
                cfg.CreateMap<AuthorPostModel, AuthorModel>();

                cfg.CreateMap<WishListModel, WishListPostModel>();
                cfg.CreateMap<WishListPostModel, WishListModel>();

                cfg.CreateMap<GenreModel, GenrePostModel>();
                cfg.CreateMap<GenrePostModel, GenreModel>();

            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
           .As<IMapper>()
           .InstancePerLifetimeScope();
        }
    }
}