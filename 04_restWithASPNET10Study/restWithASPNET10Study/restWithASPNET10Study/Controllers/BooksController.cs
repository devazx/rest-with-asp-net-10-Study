using Microsoft.AspNetCore.Mvc;
using restWithASPNET10Study.Model;
using restWithASPNET10Study.Services;

namespace restWithASPNET10Study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private IBooksService _booksService;
        private readonly ILogger<BooksController> _logger;
        public BooksController(IBooksService booksService, ILogger<BooksController> logger)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all users");
            return Ok(_booksService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Getting user with ID: {id}", id);
            var user = _booksService.FindById(id);
            if (user == null)
            {
                _logger.LogError("User with ID: {id} not found", id);
                return NotFound();
            }
            _logger.LogInformation("User with ID: {id} found", id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book books)
        {
            _logger.LogInformation("Create a book: {firstName}", books.Title);
            return Ok(_booksService.Create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book books)
        {
            _logger.LogInformation("Update User with id: {Id}", books.Id);
            var updatedUser = _booksService.Update(books);
            if (updatedUser == null) { 
                _logger.LogError("User with ID: {id} not found for update", books.Id);
                return NotFound(); }
            _logger.LogInformation("User with ID: {id} updated successfully", books.Id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete Book with ID: {id}", id);
            var books = _booksService.FindById(id);
            if (books == null) { 
                _logger.LogError("User with ID: {id} not found for deletion", id);
                return NotFound(); }
            _booksService.Delete(id);
            _logger.LogInformation("User with ID: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
