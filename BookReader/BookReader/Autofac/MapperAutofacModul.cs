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
            })).AsSelf().SingleInstance();
        }
    }
}