using Autofac;
using Autofac.Integration.Mvc;
using BookReader.Data.Interfaces;
using BookReader.Data.Repositories;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Services;
using System.Web.Mvc;

namespace BookReader.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<BookService>().As<IBookService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            builder.RegisterType<GenreRepository>().As<IGenreRepository>();
            builder.RegisterType<GenreService>().As<IGenreService>();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();

            builder.RegisterType<WishListRepository>().As<IWishListRepository>();
            builder.RegisterType<WishListService>().As<IWishListService>();

            builder.RegisterModule<MapperAutofacModul>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}