using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Dtos
{
    public class PatronDto
    {
        public string Name { get; set; }
        public string contactInformation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
