using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
           return await _context.Books.Include(b=>b.BorrwingRecords).ToListAsync();

        }

        public async Task<Book> GetById(int id)
        {
            return await _context.Books.Include(b => b.BorrwingRecords).SingleOrDefaultAsync(b => b.Id == id);
             
        }
        public async Task<Book> Create(Book book)
        {
            await _context.Books.AddAsync(book);
            _context.SaveChanges();
            return book;
        }

        public Book Delete(Book book)
        {
            _context.Remove(book);
            _context.SaveChanges();
            return book;
        }

        

        public Book Update(Book book)
        {
            _context.Update(book);
            _context.SaveChanges();
             return book;
        }
    }
}
