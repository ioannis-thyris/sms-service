using API.Filters;
using AutoMapper;
using DataTransferObjects;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using SmsVendors.Contracts;

namespace API.Controllers
{
    [ApiController]
    [Route("api/sms")]
    public class SmsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ISmsVendor Vendor { get; set; }

        public SmsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ServiceFilter(typeof(VendorFilter))] // Vendor get initialized here
        [ServiceFilter(typeof(ValidationFilter))]
        public async Task<IActionResult> Create([FromBody] SmsDto dto)
        {
            var sms = _mapper.Map<Sms>(dto);

            var vendorResponse = await Vendor.Send(sms);

            return vendorResponse.Successful ? Ok("The message was sent successfully.") : BadRequest();
        }
    }
}
