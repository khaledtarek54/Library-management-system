using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReturnController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{bookId}/patron/{patronId}")]
        public async Task<IActionResult> borrow(int bookId, int patronId)
        {
           var record = await _context.BorrwingRecords.SingleOrDefaultAsync(b => b.BookId == bookId && b.PatronId == patronId);
            if (record == null)
            {
                return  NotFound("No borrowing was found by this Id");
            }
            record.ReturnDate = DateTime.Now;
            _context.SaveChanges();
            return Ok(record);
        }
    }

}
