using Microsoft.AspNetCore.Mvc;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using ProjektInzOp.Service;

namespace ProjektInzOp.Controllers
{
    public class TitleController : ControllerBase
    {
        private readonly TitleService _titleService;

        public TitleController(TitleService Service)
        {
            _titleService = Service;
        }

        [HttpGet("titles")]
        public async Task<IEnumerable<TitleDto>> Read() => await _titleService.Get();

        [HttpGet("titles/{id}")]
        public async Task<IActionResult> ReadById(long id)
        {
            var Dto = await _titleService.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }

        [HttpPost("title")]
        public async Task<IActionResult> Create([FromBody] TitleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _titleService.Create(dto);

            return Ok(operationResult);
        }
        [HttpPatch("title")]
        public async Task<IActionResult> Update([FromBody] TitleDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _titleService.Update(dto.ToEntity());
            if (!operationResult) return NotFound();
            return Ok();
        }
        [HttpDelete("titles/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Dto = await _titleService.Delete(id);

            if (!Dto)
            {
                return NotFound();
            }

            return Ok(Dto);
        }
    }
}
