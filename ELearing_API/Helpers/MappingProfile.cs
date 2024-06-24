using AutoMapper;
using ELearing_API.Models;
using FileApload_FluentValidation.DTOs.Abouts;
using FileApload_FluentValidation.DTOs.Sliders;
using FileApload_FluentValidation.Models;

namespace ELearing_API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Slider, SliderDTo>();
            CreateMap<SliderCreateDTo, Slider>();
            CreateMap<SliderEditDTo, Slider>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));



            CreateMap<About, AboutDTo>();
            CreateMap<AboutCreateDTo, About>();
            CreateMap<AboutEditDTo, About>().ForMember(dest => dest.Image, opt => opt.Condition(src => (src.Image is null)));
        }
    }
}
