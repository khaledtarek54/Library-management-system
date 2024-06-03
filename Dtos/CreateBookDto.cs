using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dtos
{
    public class CreateBookDto
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
