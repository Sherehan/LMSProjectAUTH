using AutoMapper;
using LMSProject.Application.Repository.Interface;
using LMSProject.Data.Models;
using LMSProjectAUTH.Application.ViewModel.LibrarianDB;
using LMSProjectAUTH.Application.ViewModel.Member;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMSProjectAUTH.Application.Services
{
    public class LibrarianService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly AppDBContext _dbContext;
        private readonly PenaltyService _penaltyService;

        public LibrarianService(IUnitOfWork unitOfWork, IMapper mapper,
            AppDBContext appDBContext)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = mapper;
            _dbContext = appDBContext;
        }

        public async Task<int> GetLibrarianIdByApplicationIDAsync(string applicationUserId)
        {
            // Call the repository method to get the librarian
            var librarian = await _unitOfWork.Librarian.GetLibrarianByApplicationUserIdAsync(applicationUserId);

            // If a librarian is found, return the ID; otherwise, return 0
            if (librarian != null)
            {
                return librarian.Id; // Return the librarian's ID
            }

            return 0; // Return 0 if no librarian is found
        }

        public LibrarianStatisticVM GetLibrarianStatistic()
        {
            LibrarianStatisticVM model = new LibrarianStatisticVM
            {
               
                Bookstotal = _dbContext.Books.ToList().Count(),
                BookCopiesstotal = _dbContext.BookStores.ToList().Count(),
                UnBorrowedBooks = _dbContext.BookStores.Count(x => x.IsAvaliable),
                BorrowedBooks = _dbContext.BookStores.Count(x => !x.IsAvaliable),
                DelayedBook= _dbContext.Borrows.Count(x => x.ReturnDate == null && x.DefaultReturnDate < DateTime.Today)

            };



            return model;
        }
    }
}
