using BookStoreApi.Models;
using BookStoreApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookRepository.GetAllBooksAsync());
        }

        [HttpGet("/title")]
        public async Task<IActionResult> GetOnlyAllBooksTitle()
        {
            return Ok(await _bookRepository.GetOnlyAllBooksTitleAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var books = await _bookRepository.AddBookAsync(bookModel);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookAsync(id, bookModel);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok("Deleted");
        }
    }
}
