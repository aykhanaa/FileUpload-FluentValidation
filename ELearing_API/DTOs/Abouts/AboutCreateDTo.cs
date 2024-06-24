
using FluentValidation;
using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Abouts
{
    public class AboutCreateDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile UploadImage { get; set; }
    }

    public class AboutCreateDToValidator : AbstractValidator<AboutCreateDTo>
    {
        public AboutCreateDToValidator()
        {
            RuleFor(m => m.Title).NotNull().WithMessage("Title  is required");
            RuleFor(m => m.Description).NotEmpty().NotNull();
        }
    }
}
