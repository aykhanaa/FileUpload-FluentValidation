using FileApload_FluentValidation.DTOs.Abouts;
using System.Threading.Tasks;

namespace FileApload_FluentValidation.Services.Interface
{
    public interface IAboutService
    {
        Task CreateAsync(AboutCreateDTo request);
        Task EditAsync(int id, AboutEditDTo request);
        Task DeleteAsync(int id);
        Task<List<AboutDTo>> GetAllAsync();
        Task<AboutDTo> GetByIdAsync(int id);
    }
}
