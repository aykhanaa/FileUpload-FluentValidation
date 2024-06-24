using AutoMapper;
using ELearing_API.Data;
using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Models;
using FileApload_FluentValidation.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace FileApload_FluentValidation.Services
{
    public class SliderService : ISliderService
    {


        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public SliderService(AppDbContext context,
                             IWebHostEnvironment env,
                             IMapper mapper)
        {
            _context = context;
            _env = env;
            _mapper = mapper;

        }

        public async Task CreateAsync(SliderCreateDTo data)
        {
            string fileName = $"{Guid.NewGuid()}-{data.UploadImage.FileName}";

            string path = Path.Combine(_env.WebRootPath, "img", fileName);

            using (FileStream stream = new(path, FileMode.Create))
            {
                await data.UploadImage.CopyToAsync(stream);
            }

            data.Image = fileName;

            await _context.Sliders.AddAsync(_mapper.Map<Slider>(data));

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var existSlider = await _context.Sliders.FindAsync(id);
            string path = Path.Combine(_env.WebRootPath, "img", existSlider.Image);

            if (File.Exists(path))
                File.Delete(path);

            _context.Sliders.Remove(existSlider);
            await _context.SaveChangesAsync();
        }


        public async Task EditAsync(int id, SliderEditDTo data)
        {
            var existSlider = await _context.Sliders.FindAsync(id);
            if (data.UploadImage is not null)
            {
                string oldPath = Path.Combine(_env.WebRootPath, "img", existSlider.Image);
                if (File.Exists(oldPath))
                    File.Delete(oldPath);

                string fileName = Guid.NewGuid().ToString() + "-" + data.UploadImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "img", fileName);

                using (FileStream stream = new(newPath, FileMode.Create))
                {
                    await data.UploadImage.CopyToAsync(stream);
                }


                data.Image = fileName;
            }

            _mapper.Map(data, existSlider);

            await _context.SaveChangesAsync();

        }

        public async Task<List<SliderDTo>> GetAllAsync()
        {
            return _mapper.Map<List<SliderDTo>>(await _context.Sliders.AsTracking().ToListAsync());
        }

        public async Task<SliderDTo> GetByIdAsync(int id)
        {
            return _mapper.Map<SliderDTo>(await _context.Sliders.AsTracking().FirstOrDefaultAsync(m => m.Id == id));
        }
    }
}
