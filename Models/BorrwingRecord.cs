namespace LibraryManagementSystem.Models
{
    public class BorrwingRecord
    {   
        public int Id { get; set; }
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public DateTime BorrwingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book Book { get; set; }
        public Patron Patron { get; set; }
    }
}
