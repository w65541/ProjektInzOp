using Microsoft.AspNetCore.Mvc;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using ProjektInzOp.Service;

namespace ProjektInzOp.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;

        public BookController(BookService Service)
        {
            _bookService = Service;
        }

        
        [HttpGet("books")]
        public async Task<IEnumerable<BookDto>> Read() => await _bookService.Get();

        
        [HttpGet("books/{id}")]
        public async Task<IActionResult> ReadById(long id)
        {
            var Dto = await _bookService.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }


        [HttpPost("book")]
        public async Task<IActionResult> Create([FromBody] BookDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _bookService.Create(dto);

            return Ok(operationResult);
        }
        [HttpPatch("books")]
        public async Task<IActionResult> Update([FromBody] BookDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _bookService.Update(dto.ToEntity());
            if (!operationResult) return NotFound();
            return Ok();
        }
        [HttpDelete("books/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Dto = await _bookService.Delete(id);

            if (!Dto)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("bookBorrow/{bookId}&{userId}")]
        public async Task<IActionResult> Borrow(long bookId, long userId)
        {
            
            var operationResult = await _bookService.BorrowBook(bookId,userId);
            if (!operationResult) return BadRequest("Book already borrowed");
            return Ok(operationResult);
        }
        [HttpPost("bookReturn/{bookId}")]
        public async Task<IActionResult> Return(long bookId)
        {

            var operationResult = await _bookService.ReturnBook(bookId);
            if (!operationResult) return BadRequest();
            return Ok(operationResult);
        }
    }
}
