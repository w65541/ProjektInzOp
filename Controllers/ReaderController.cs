using Microsoft.AspNetCore.Mvc;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using ProjektInzOp.Service;

namespace ProjektInzOp.Controllers
{
    public class ReaderController : ControllerBase
    {
        private readonly ReaderService _readerService;

        public ReaderController(ReaderService Service)
        {
            _readerService = Service;
        }

        [HttpGet("readers")]
        public async Task<IEnumerable<ReaderDto>> Read() => await _readerService.Get();


        [HttpGet("readers/{id}")]
        public async Task<IActionResult> ReadById(long id)
        {
            var Dto = await _readerService.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("readers")]
        public async Task<IActionResult> Create([FromBody] ReaderDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _readerService.Create(dto);

            return Ok(operationResult);
        }
        [HttpPatch("readers")]
        public async Task<IActionResult> Update([FromBody] ReaderDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _readerService.Update(dto.ToEntity());
            if (!operationResult) return NotFound();
            return Ok();
        }
        [HttpDelete("readers/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Dto = await _readerService.Delete(id);

            if (!Dto)
            {
                return NotFound();
            }

            return Ok(Dto);
        }
    }
}
