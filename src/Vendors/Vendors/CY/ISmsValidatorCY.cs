using DataTransferObjects;
using FluentValidation;

namespace SmsVendors.Vendors.CY
{
    public interface ISmsValidatorCY : IValidator<SmsDto>
    {
    }
}
