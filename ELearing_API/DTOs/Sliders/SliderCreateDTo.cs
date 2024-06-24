
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Sliders
{
    public class SliderCreateDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; } 
        public IFormFile UploadImage { get; set; }

    }

    public class SliderCreateDToValidator : AbstractValidator<SliderCreateDTo>
    {
        public SliderCreateDToValidator()
        {
            RuleFor(m => m.Title).NotNull().WithMessage("Title PB-101 is required");
            RuleFor(m => m.Description).NotEmpty().NotNull();
        }
    }

}
