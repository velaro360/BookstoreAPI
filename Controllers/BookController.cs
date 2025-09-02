using BookstoreAPI.Application.Model;
using BookstoreAPI.Application.Service;
using BookstoreAPI.Controllers.Requests.BookRequests;
using BookstoreAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<BookDTO>> GetBookAsync([FromRoute] int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if(book == null)
            {
                return NotFound($"Book with ID {id} not found.");
            }

            return Ok(book);
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();

            if (books == null || !books.Any())
            {
                return NotFound("No books found.");
            }

            return Ok(books);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteBookAsync([FromBody] UpdateBookRequest book)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            if (book == null)
            {
                return BadRequest("Book object is null.");
            }

            var deleted = await _bookService.DeleteBookAsync(book);
            if (!deleted)
            {
                return NotFound($"Book with ID {book.Id} not found.");
            }

            return Ok($"Book with ID {book.Id} deleted.");
        }

        [HttpPut]
        [Route("add")]
        public async Task<IActionResult> AddBookAsync([FromBody] CreateBookRequest book)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            await _bookService.AddBookAsync(book);

            return Ok();
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> UpdateBookAsync([FromBody] UpdateBookRequest book)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            await _bookService.UpdateBookAsync(book);

            return Ok();
        }
    }
}