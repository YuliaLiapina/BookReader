using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BookReader.Data;
using BookReader.Data.Interfaces;
using BookReader.Data.Repositories;
using BookReaderManager.Business;
using BookReaderManager.Business.Interfaces;
using BookReaderManager.Business.Services;

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
            builder.RegisterModule<MapperAutofacModul>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}