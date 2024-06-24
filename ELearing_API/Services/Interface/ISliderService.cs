using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Models;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface ISliderService
    {
        Task CreateAsync(SliderCreateDTo data);
        Task EditAsync(int id, SliderEditDTo data);
        Task DeleteAsync(int id);
        Task<List<SliderDTo>> GetAllAsync();
        Task<SliderDTo> GetByIdAsync(int id);
    }
}
