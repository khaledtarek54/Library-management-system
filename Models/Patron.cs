namespace LibraryManagementSystem.Models
{
    public class Patron
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string contactInformation { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public List<BorrwingRecord> BorrwingRecords { get; set; }


    }
}
