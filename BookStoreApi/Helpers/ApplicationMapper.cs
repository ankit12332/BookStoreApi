using AutoMapper;
using BookStoreApi.Entity;
using BookStoreApi.Models;

namespace BookStoreApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}
