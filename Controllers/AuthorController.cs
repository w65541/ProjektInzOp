using Microsoft.AspNetCore.Mvc;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using ProjektInzOp.Service;

namespace ProjektInzOp.Controllers
{
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("authors")]
        public async Task<IEnumerable<AuthorDto>> Read() => await _authorService.Get();


        [HttpGet("authors/{id}")]
        public async Task<IActionResult> ReadById(long id)
        {
            var Dto = await _authorService.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }


        [HttpPost("author")]
        public async Task<IActionResult> Create([FromBody] AuthorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _authorService.Create(dto);

            return Ok(operationResult);
        }
        [HttpPatch("authors")]
        public async Task<IActionResult> Update( [FromBody] AuthorDto dto)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _authorService.Update(dto.ToEntity());
            if(!operationResult) return NotFound();
            return Ok();
        }
        [HttpDelete("authors/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Dto = await _authorService.Delete(id);

            if (!Dto)
            {
                return NotFound();
            }

            return Ok(Dto);
        }
    }
}

