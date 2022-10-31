using DataTransferObjects;
using FluentValidation;

namespace SmsVendors.Vendors.Rest
{
    public interface ISmsValidatorRest : IValidator<SmsDto>
    {
    }
}
