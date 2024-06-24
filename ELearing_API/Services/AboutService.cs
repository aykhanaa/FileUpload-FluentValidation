using AutoMapper;
using ELearing_API.Data;
using ELearing_API.Models;
using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace FileApload_FluentValidation.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public AboutService(AppDbContext context,
                            IWebHostEnvironment env,
                            IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }

        public async Task CreateAsync(AboutCreateDTo request)
        {
            string fileName = $"{Guid.NewGuid()}-{request.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await request.UploadImage.CopyToAsync(stream);
            }

            request.Image = fileName;

            await _context.Abouts.AddAsync(_mapper.Map<About>(request));

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Abouts.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existSlider.Image);

            if (File.Exists(path))
                File.Delete(path);

            _context.Abouts.Remove(existSlider);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditDTo request)
        {
            var existSlider = await _context.Abouts.FindAsync(id);
            if (request.UploadImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existSlider.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + request.UploadImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await request.UploadImage.CopyToAsync(stream);
                }


                request.Image = fileName;
            }

            _mapper.Map(request, existSlider);

            await _context.SaveChangesAsync();

        }

        public async Task<List<AboutDTo>> GetAllAsync()
        {
            return _mapper.Map<List<AboutDTo>>(await _context.Abouts.AsTracking().ToListAsync());
        }

        public async Task<AboutDTo> GetByIdAsync(int id)
        {
            return _mapper.Map<AboutDTo>(await _context.Abouts.AsTracking().FirstOrDefaultAsync(m => m.Id == id));

        }

    }
}
