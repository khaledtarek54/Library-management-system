using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllBooksAsync()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getSingleBookAsync(int id)
        {
            var books = await _bookService.GetById(id);
            if (books == null)
            {
                return NotFound("No Book was found");
            }
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> createBookAsync(CreateBookDto bookDto)
        {
            var book = new Book {
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublicationYear = bookDto.PublicationYear,
                ISBN = bookDto.ISBN,
                CreatedDate = DateTime.Now,
            };
            book = await _bookService.Create(book);
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, CreateBookDto bookDto)
        {
            var book  = await _bookService.GetById(id);

            if(book == null)
            {
                return NotFound($"No book found with this id {id}");
            }

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.ISBN = bookDto.ISBN;
            book.PublicationYear = bookDto.PublicationYear;
            book.ModifiedDate = bookDto.ModifiedDate;
            book = _bookService.Update(book);

            return Ok(book);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return NotFound($"No book found with this id {id}");
            }
            _bookService.Delete(book);
            return Ok();
        }
    }
}
