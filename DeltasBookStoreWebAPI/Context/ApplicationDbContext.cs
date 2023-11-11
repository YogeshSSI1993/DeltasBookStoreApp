using DeltasBookStoreAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeltasBookStoreAppWebAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookDetails> BookDetails { get; set; }

    }
}
