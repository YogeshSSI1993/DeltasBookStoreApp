using DeltasBookStoreAppWebAPI.Context;
using DeltasBookStoreAppWebAPI.Interface;
using DeltasBookStoreAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltasBookStoreAppWebAPI.Implimentation
{
    public class BookDetailsRepository : IBookDetailsRepository
    {
        private readonly ApplicationDbContext _context;
        public BookDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<BookDetails>> GetBookDetails()
        {
            return await _context.BookDetails.Where(x => x.IsActive == "Y").ToListAsync();
        }

        public async Task<BookDetails> GetBookDetails(int Id)
        {
            return await _context.BookDetails.FindAsync(Id);
        }

        public async Task<int> PutBookDetails(BookDetails bookDetails)
        {
            if (_context.BookDetails != null)
            {
                _context.Entry(bookDetails).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 99;
            }
        }

        public async Task<int> PostBookDetails(BookDetails bookDetails)
        {
            if (_context.BookDetails != null)
            {
                _context.BookDetails.Add(bookDetails);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 99;
            }
        }

        public async Task<int> DeleteBookDetails(int Id)
        {

            if (_context.BookDetails != null)
            {
                var bookDetails = await _context.BookDetails.FindAsync(Id);
                bookDetails.IsActive = "N";
                _context.Entry(bookDetails).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 99;
            }
        }

        public async Task<bool> BookDetailsExists(int Id)
        {
            if (_context.BookDetails != null)
            {
                return (_context.BookDetails?.Any(e => e.Id == Id)).GetValueOrDefault();
            }
            else
            {
                return false;
            }
        }

        public async Task<List<BookDetails>> GetDeletedBookDetails()
        {
            return await _context.BookDetails.Where(x => x.IsActive == "N").ToListAsync();
        }
    }
}
