using AutoMapper;
using Domain.Models;

namespace DataTransferObjects
{
    public class SmsProfile : Profile
    {
        public SmsProfile()
        {
            CreateMap<Sms, SmsDto>()
                .ReverseMap();
        }
    }
}
