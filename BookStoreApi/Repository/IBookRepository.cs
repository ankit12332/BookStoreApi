using BookStoreApi.Models;

namespace BookStoreApi.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<List<BookModel>> GetOnlyAllBooksTitleAsync();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int bookId, BookModel bookModel);
        Task DeleteBookAsync(int bookId);
    }
}
