using FluentValidation;

namespace SmsVendors.Vendors.CY
{
    public class SmsValidatorCY : SmsValidatorBase, ISmsValidatorCY
    {
        public SmsValidatorCY() : base()
        {
            RuleFor(m => m.Number).Matches(@"^\+[3][5][7]\d{8,8}$")
                .WithMessage("The telephone number provided is not a valid CY number. Check: 'https://en.wikipedia.org/wiki/Telephone_numbers_in_Cyprus'");
        }

    }
}
