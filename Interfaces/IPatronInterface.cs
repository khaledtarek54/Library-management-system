using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IPatronInterface
    {
        Task<IEnumerable<Patron>> GetAll();
        Task<Patron> GetById(int id);
        Task<Patron> Create(Patron patron);
        Patron Update(Patron patron);
        Patron Delete(Patron patron);
    }
}
