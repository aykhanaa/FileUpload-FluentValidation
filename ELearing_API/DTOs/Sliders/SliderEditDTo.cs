using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Sliders
{
    public class SliderEditDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }
    }
}
