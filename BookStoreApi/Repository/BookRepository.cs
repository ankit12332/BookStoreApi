using AutoMapper;
using BookStoreApi.Data;
using BookStoreApi.Entity;
using BookStoreApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            //var allBooks = await _context.Books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).ToListAsync();
            //return allBooks;
            var allBooks =await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(allBooks);
        }

        public async Task<List<BookModel>> GetOnlyAllBooksTitleAsync()
        {
            var title = await _context.Books.Select(x => new BookModel()
            {
                Title = x.Title,
            }).ToListAsync();
            return title;
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            //------------------1----------------------
            //var book = await _context.books.select(x => new bookmodel()
            //{
            //    id = x.id,
            //    title = x.title,
            //    description = x.description,
            //}).firstordefaultasync();
            //return book;
            //------------------2-------------------
            //var book = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel(){
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description,
            //}).FirstOrDefaultAsync();
            //return book;
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            //var book = await _context.Books.FindAsync(bookId);
            //if(book != null)
            //{
            //    book.Title = bookModel.Title;
            //    book.Description = bookModel.Description;
            //    await _context.SaveChangesAsync();
            //}
            var book = new Books()
            {
                Id=bookId,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId,
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        
    }
}
