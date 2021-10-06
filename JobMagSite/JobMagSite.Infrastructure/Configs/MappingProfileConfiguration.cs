using AutoMapper;
using JobMagSite.Domain.Entities;
using JobMagSite.Service.DTO.Request;
using JobMagSite.Service.DTO.Response;

namespace JobMagSite.Infrastructure.Configs
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Person, CreatePersonRequest>().ReverseMap();
            CreateMap<Person, UpdatePersonRequest>().ReverseMap();
            CreateMap<Person, PersonQueryResponse>().ReverseMap();
            CreateMap<Student, StudentQueryResponse>().ReverseMap();
        }
    }
}
