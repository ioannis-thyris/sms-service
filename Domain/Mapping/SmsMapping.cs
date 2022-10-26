using AutoMapper;
using Domain.DataTransferObjects;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapping
{
    public class SmsMapping : Profile
    {
        public SmsMapping()
        {
            CreateMap<Sms, SmsDto>()
                .ReverseMap();
        }
    }
}
