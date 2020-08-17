﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using BookReader.Data;
using BookReader.Data.Interfaces;
using BookReaderManager.Business;
using BookReaderManager.Business.Interfaces;

namespace BookReader.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<BookManager>().As<IbookManager>();
            builder.RegisterModule<MapperAutofacModul>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}