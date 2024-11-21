using System.ComponentModel.DataAnnotations;

namespace LMSProjectAUTH.Application.ViewModel.Book
{
    public class Top5BooksVM
    {
        public string Title { get; set; }
        public string GenreType { get; set; }

        public string AuthorName { get; set; }

        [Display(Name = "Photo")]
        public byte[] BookPhoto { get; set; }

        public int BookCount { get; set; }
    }

   
}
