using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BorrowController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> borrow(BorrwingRecordDto borrwingRecordDto)
        {
            var record = new BorrwingRecord {
                BookId = borrwingRecordDto.BookId,
                PatronId = borrwingRecordDto.PatronId,
                BorrwingDate = DateTime.Now
            };
            await _context.BorrwingRecords.AddAsync(record);
            _context.SaveChanges();
            return Ok(record);
        }
    }
}
