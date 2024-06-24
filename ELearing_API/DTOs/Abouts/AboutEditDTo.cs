using Swashbuckle.AspNetCore.Annotations;

namespace FileApload_FluentValidation.DTOs.Abouts
{
    public class AboutEditDTo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string? Image { get; set; }
        public IFormFile? UploadImage { get; set; }

    }
}
