using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatronController : ControllerBase
    {
        private readonly IPatronInterface _patronService;

        public PatronController(IPatronInterface patronService)
        {
            _patronService = patronService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllpatronsAsync()
        {
            var patrons = await _patronService.GetAll();
            return Ok(patrons);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getSingleBookAsync(int id)
        {
            var patrons = await _patronService.GetById(id);
            if (patrons == null)
            {
                return NotFound("No patron was found");
            }
            return Ok(patrons);
        }
        [HttpPost]
        public async Task<IActionResult> createBookAsync(PatronDto PatronDto)
        {
            var patron = new Patron
            {
                Name = PatronDto.Name,
                contactInformation = PatronDto.contactInformation,
                CreatedDate = DateTime.Now,
            };
            patron = await _patronService.Create(patron);
            return Ok(patron);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, PatronDto PatronDto)
        {
            var patron = await _patronService.GetById(id);

            if (patron == null)
            {
                return NotFound($"No Patron found with this id {id}");
            }

            patron.Name = PatronDto.Name;
            patron.contactInformation = PatronDto.contactInformation;
            patron.ModifiedDate = DateTime.Now;

            patron = _patronService.Update(patron);

            return Ok(patron);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var patron = await _patronService.GetById(id);
            if (patron == null)
            {
                return NotFound($"No Patron found with this id {id}");
            }
            _patronService.Delete(patron);
            return Ok();
        }
    }
}
