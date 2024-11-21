using LMSProject.Data.Models;
using LMSProjectAUTH.Application.ViewModel.AdminDB;
using Microsoft.EntityFrameworkCore;

namespace LMSProjectAUTH.Application.Services
{
    public class AdminDBService
    {
        private readonly AppDBContext _context;

        public AdminDBService(AppDBContext context)
        {
            _context = context;
        }

        public  StatisticVM GetMainStatistic()
        {
            var model = new StatisticVM
            {
                Membertotol = _context.Members.Count(),
                Bookstotal = _context.Books.Count(),
                BookCopiesstotal = _context.Books.Count(),
                Totalauthor = _context.Authors.Count(),
                Totalgenre = _context.Genres.Count(),

                UnBorrowedBooks = _context.BookStores.Count(a => a.IsAvaliable),
                BorrowedBooks = _context.BookStores.Count(a => !a.IsAvaliable),
                DelayedBook = _context.Borrows.Count(x => x.ReturnDate == null && x.DefaultReturnDate < DateTime.Today),
               
                TopBorrowedBooks = _context.Borrows
                           .Include(b => b.BookStore)
                           .ThenInclude(bs => bs.Book)
                           .ThenInclude(b => b.Authors)
                           .GroupBy(b => b.BookStore.Book)
                           .Select(g => new TopBorrowedBooks
                           {
                               Title = g.Key.Title,
                               Author = _context.Authors
                                      .Where(a => a.Id == g.Key.AuthorId)
                                       .Select(a => a.Name)
                                        .FirstOrDefault() ?? "N/A",
                               BookPhoto = g.Key.BookPhoto,
                               BorrowedBookCount = g.Count()
                           })
                           .OrderByDescending(x => x.BorrowedBookCount)
                           .Take(4)
                           .ToList()
            };

            return model;
        }
    
    }
}
