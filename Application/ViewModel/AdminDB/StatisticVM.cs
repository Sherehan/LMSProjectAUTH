

namespace LMSProjectAUTH.Application.ViewModel.AdminDB
{
    public class StatisticVM
    {
        public int Membertotol { get; set; }
        public int Bookstotal { get; set; }
        public int BookCopiesstotal { get; set; }
        public int Totalauthor { get; set; }
        public int Totalgenre { get; set; }
        public int UnBorrowedBooks { get; set; }
        public int BorrowedBooks { get; set; }

        public int DelayedBook { get; set; }

        public IEnumerable<TopBorrowedBooks> TopBorrowedBooks { get; set; }
    }
}
