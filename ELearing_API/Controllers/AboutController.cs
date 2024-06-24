using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileApload_FluentValidation.Controllers
{
    public class AboutController : BaseController
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AboutCreateDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _aboutService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), request);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _aboutService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            await _aboutService.GetByIdAsync(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _aboutService.DeleteAsync(id);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] AboutEditDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _aboutService.EditAsync(id, request);
            return Ok();

        }
    }
}
