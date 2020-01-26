using _Lab_Library.Data;
using _Lab_Library.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabWebAPI_17_1_2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;
        public HomeController(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<List<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBooksByAuthorId(int id)
        {
            return Ok(await _dbContext.AuthorBooks
                                    .Where(x => x.AuthorId == id)
                                        .Select(x => new { x.Book.Name, x.Book.Id })
                                            .ToListAsync());
        }
        [HttpGet("{bookid}")]
        public async Task<IActionResult> GetAllLanguagesByBookId(int bookid)
        {
            return Ok(await _dbContext.BookLanguages
                                           .Where(x => x.BookId == bookid)
                                                .Select(x => new { x.Language.Name })
                                                    .ToListAsync());
        }

    }
}