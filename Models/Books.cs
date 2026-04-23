namespace LibraryManagementSystemWebApplication.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }
        public int? BorrowerId { get; set; }

        //public virtual Student Borrower { get; set; }
    }
}
