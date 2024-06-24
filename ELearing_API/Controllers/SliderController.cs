using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Helpers.Extensions;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileApload_FluentValidation.Controllers
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SliderCreateDTo request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _sliderService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), request);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _sliderService.GetByIdAsync(id));
        }


        [HttpPatch]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _sliderService.DeleteAsync(id);
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] SliderEditDTo request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _sliderService.EditAsync(id, request);

            return Ok();
        }



    }
}
