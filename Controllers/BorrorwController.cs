using Microsoft.AspNetCore.Mvc;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using ProjektInzOp.Service;

namespace ProjektInzOp.Controllers
{
    public class BorrorwController : ControllerBase
    {
        private readonly BorrowService _borrowService;

        public BorrorwController(BorrowService Service)
        {
            _borrowService = Service;
        }

        [HttpGet("borrows")]
        public async Task<IEnumerable<BorrowDto>> Read() => await _borrowService.Get();

        [HttpGet("borrows/{id}")]
        public async Task<IActionResult> ReadById(long id)
        {
            var Dto = await _borrowService.GetById(id);

            if (Dto == null)
            {
                return NotFound();
            }

            return Ok(Dto);
        }


        [HttpPost("borrow")]
        public async Task<IActionResult> Create([FromBody] BorrowDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operationResult = await _borrowService.Create(dto);

            return Ok(operationResult);
        }
        [HttpPatch("borrows")]
        public async Task<IActionResult> Update([FromBody] BorrowDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operationResult = await _borrowService.Update(dto.ToEntity());
            if (!operationResult) return NotFound();
            return Ok();
        }
        [HttpDelete("borrows/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var Dto = await _borrowService.Delete(id);

            if (!Dto)
            {
                return NotFound();
            }

            return Ok(Dto);
        }
    }
}
