using DataTransferObjects;
using FluentValidation;

namespace SmsVendors.Vendors
{
    public class SmsValidatorBase : AbstractValidator<SmsDto>
    {
        public SmsValidatorBase() : base()
        {
            RuleFor(m => m.Text).NotEmpty()
                    .WithMessage("Cannot send an empty message.");

            RuleFor(m => m.Number).NotEmpty()
                                  .MinimumLength(7)
                                  .MaximumLength(15);

            RuleFor(m => m.Number).Matches(@"^\+[1-9]\d{1,14}$")
                .WithMessage("Wrong telephone number format, please use '+(country code)(subscriber number)'. Check: https://en.wikipedia.org/wiki/E.164");

        }
    }
}
