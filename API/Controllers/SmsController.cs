using API.Filters;
using AutoMapper;
using Domain.DataTransferObjects;
using Domain.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmsVendors.Core;

namespace API.Controllers
{
    [ApiController]
    [Route("api/sms")]
    public class SmsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ISmsVendor Vendor { get; private set; }

        public SmsController(IMapper mapper, ISmsVendor vendor)
        {
            _mapper = mapper;
            Vendor = vendor;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Create([FromBody] SmsDto dto)
        {
            var sms = _mapper.Map<Sms>(dto);

            var sentSuccess = await Vendor.Send(sms);

            return sentSuccess ? Ok() : BadRequest();
        }
    }
}
