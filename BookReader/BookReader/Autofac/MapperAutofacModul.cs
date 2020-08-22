using Autofac;
using AutoMapper;
using BookReader.Data.Models;
using BookReader.Models;
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