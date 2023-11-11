using DeltasBookStoreAppWebAPI.Models;

namespace DeltasBookStoreAppWebAPI.Interface
{
    public interface IBookDetailsRepository
    {
        Task<List<BookDetails>> GetBookDetails();
        Task<BookDetails> GetBookDetails(int Id);

        Task<int> PutBookDetails(BookDetails bookDetails);

        Task<bool> BookDetailsExists(int Id);

        Task<int> PostBookDetails(BookDetails bookDetails);

        Task<int> DeleteBookDetails(int Id);

        Task<List<BookDetails>> GetDeletedBookDetails();
    }
}
