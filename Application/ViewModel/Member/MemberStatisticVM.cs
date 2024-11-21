namespace LMSProjectAUTH.Application.ViewModel.Member
{
    public class MemberStatisticVM
    {
        public int TotalBorrowsBookTillNow { get; set; }

        public int TotalBorrowedBooks { get; set; }
        public int DelayedBook { get; set; }
        public double Score { get; set; }
    }
}
