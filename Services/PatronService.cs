using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Services
{
    public class PatronService : IPatronInterface
    {
        private readonly ApplicationDbContext _context;
        public PatronService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patron>> GetAll()
        {
            return await _context.Patrons.Include(b => b.BorrwingRecords).ToListAsync();
        }

        public async Task<Patron> GetById(int id)
        {
            return await _context.Patrons.Include(b => b.BorrwingRecords).SingleOrDefaultAsync(b => b.Id == id);
        }
        public async Task<Patron> Create(Patron patron)
        {
            await _context.Patrons.AddAsync(patron);
            _context.SaveChanges();
            return patron;
        }
        public Patron Delete(Patron patron)
        {
            _context.Remove(patron);
            _context.SaveChanges();
            return patron;
        }
        public Patron Update(Patron patron)
        {
            _context.Update(patron);
            _context.SaveChanges();
            return patron;
        }
    }
}
