using Domain.DataTransferObjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.GR
{
    public class SmsValidatorGR : AbstractValidator<SmsDto>, ISmsValidatorGR
    {
        private readonly int minGreekCharacter = 0x37e;
        private readonly int maxGreekCharacter = 0x3ce;

        public SmsValidatorGR() : base()
        {
            RuleFor(m => m.Text).NotEmpty()
                                .WithMessage("Cannot send an empty message.");

            RuleFor(m => m.Number).NotEmpty()
                                  .Matches(@"^\+[1-9]\d{1,14}$")
                                  .MinimumLength(7)
                .WithMessage("Wrong Telephone number format, please use '+(country code)(Subscriber number)'. Check: https://en.wikipedia.org/wiki/E.164");

            RuleFor(m => m.Text).Must(m => IsInGreek(m))
                                .WithMessage("Only messages in Greek are supported.");
        }

        private bool IsInGreek(string text) => text.All(c => IsGreekNumberSymbol(c));

        private bool IsGreekNumberSymbol(char c)
        {
            var isGreek = !(c < minGreekCharacter || c > maxGreekCharacter);

            return isGreek || !char.IsLetter(c);
        }
    }


}
