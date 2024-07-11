using BookreviewApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookreviewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookReviewContext _context;

        public BookController(BookReviewContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            // Asynchronously fetches all products from the database and returns them
            return Ok(await _context.Books.ToArrayAsync());
        }


        [HttpPost]
        public async Task<ActionResult<BOOK>> PostProduct(BOOK bOOK)
        {
            _context.Books.Add(bOOK);
          
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetBook",
                new { id = bOOK.Id },
                bOOK);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, BOOK updatedBook)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Datepublished = updatedBook.Datepublished;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] List<int> ids)
        {
            var books = new List<BOOK>();

            foreach (var id in ids)
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return NotFound();
                }
                books.Add(book);
            }

            _context.Books.RemoveRange(books);
            await _context.SaveChangesAsync();

            return Ok(books);
        }
    }
}