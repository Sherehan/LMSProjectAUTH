namespace LMSProjectAUTH.Application.ViewModel.AdminDB
{
    public class TopBorrowedBooks
    {
        public string Title { get; set; }
        public string Author { get; set; } // Will contain concatenated author names.
        public byte[] BookPhoto { get; set; }
        public int BorrowedBookCount { get; set; }
    }
}
