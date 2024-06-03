using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublicationYear { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        [AllowNull]
        public DateTime ModifiedDate { get; set;}
        public List<BorrwingRecord> BorrwingRecords { get; set;}

    
    }
}
