using LMSProject.Data.Models;
using LMSProjectAUTH.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMSProjectAUTH.Controllers
{
    public class LibrarianDBController : Controller
    {
        private readonly AppDBContext _context;
        private readonly LibrarianService _librarianService;

        public LibrarianDBController(AppDBContext context, LibrarianService librarianService)
        {
            _context = context;
            _librarianService = librarianService;
        }
        public IActionResult Index()
        {

            var bookstotal = _context.Books.ToList().Count();
            var bookCopiesstotal = _context.BookStores.ToList().Count();
            
            var unBorrowedBooks = _context.BookStores.Where(x => x.IsAvaliable).Count();
            var BorrowedBooks = _context.BookStores.Where(x => !x.IsAvaliable).Count();
            var delayedBook = _context.Borrows.Where(x => x.ReturnDate == null && x.DefaultReturnDate < DateTime.Today).Count();

            
            ViewBag.bookstotal = bookstotal;
            ViewBag.BookCopiesstotal = bookCopiesstotal;
          
            ViewBag.unBorrowedBooks = unBorrowedBooks;
            ViewBag.BorrowedBooks = BorrowedBooks;
            ViewBag.delayedBook = delayedBook;

            var model=_librarianService.GetLibrarianStatistic();
            return View(model);
        }
    }
}
