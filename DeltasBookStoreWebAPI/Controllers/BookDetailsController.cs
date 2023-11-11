using DeltasBookStoreAppWebAPI.Interface;
using DeltasBookStoreAppWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeltasBookStoreAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailsController : ControllerBase
    {
        private readonly IBookDetailsRepository _bookDetailsRepository;

        public BookDetailsController(IBookDetailsRepository bookDetailsRepository)
        {
            _bookDetailsRepository = bookDetailsRepository;
        }

        // GET: api/BookDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetails>>> GetBookDetails()
        {
            List<BookDetails> bookDetailsList = new List<BookDetails>();
            //if (_context.BookDetails == null)
            //{
            //    return NotFound();
            //}

            bookDetailsList = (List<BookDetails>)await _bookDetailsRepository.GetBookDetails();
            return Ok(bookDetailsList);
        }

        // GET: api/BookDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetails>> GetBookDetails(int id)
        {
            var bookDetails = await _bookDetailsRepository.GetBookDetails(id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return Ok(bookDetails);
        }

        // PUT: api/BookDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookDetails(int id, BookDetails bookDetails)
        {
            int Result;
            if (id != bookDetails.Id)
            {
                return BadRequest();
            }

            try
            {
                Result = await _bookDetailsRepository.PutBookDetails(bookDetails);

                if (Result == 99)
                {
                    return Problem("Entity set 'ApplicationDbContext.BookDetails'  is null.");
                }
                else
                {
                    return Ok();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                bool IsExists = await _bookDetailsRepository.BookDetailsExists(id);
                if (!IsExists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/BookDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDetails>> PostBookDetails(BookDetails bookDetails)
        {
            int Result = await _bookDetailsRepository.PostBookDetails(bookDetails);
            if (Result == 99)
            {
                return Problem("Entity set 'ApplicationDbContext.BookDetails'  is null.");
            }

            return CreatedAtAction("GetBookDetails", new { id = bookDetails.Id }, bookDetails);
        }

        // DELETE: api/BookDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookDetails(int id)
        {
            bool IsExists = false;
            int Result;
            IsExists = await _bookDetailsRepository.BookDetailsExists(id);

            if (!IsExists)
            {
                return NotFound();
            }

            try
            {
                Result = await _bookDetailsRepository.DeleteBookDetails(id);
                if (Result == 99)
                {
                    return Problem("Entity set 'ApplicationDbContext.BookDetails'  is null.");
                }
                else
                {
                    return Ok();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                IsExists = await _bookDetailsRepository.BookDetailsExists(id);
                if (!IsExists)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // GET: api/BookDetails
        [HttpGet("GetDeletedBookDetails")]
        public async Task<ActionResult<IEnumerable<BookDetails>>> GetDeletedBookDetails()
        {
            List<BookDetails> bookDetailsList = new List<BookDetails>();
            //if (_context.BookDetails == null)
            //{
            //    return NotFound();
            //}

            bookDetailsList = (List<BookDetails>)await _bookDetailsRepository.GetDeletedBookDetails();
            return Ok(bookDetailsList);
        }
    }
}
