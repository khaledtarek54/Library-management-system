namespace LibraryManagementSystem.Dtos
{
    public class BorrwingRecordDto
    {
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public DateTime BorrwingDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
