using FluentValidation;

namespace SmsVendors.Vendors.GR
{
    public class SmsValidatorGR : SmsValidatorBase, ISmsValidatorGR
    {
        private readonly int minGreekCharacter = 0x37e;
        private readonly int maxGreekCharacter = 0x3ce;

        public SmsValidatorGR() : base()
        {
            RuleFor(m => m.Number).Matches(@"^\+[3][0]\d{10,10}$")
                .WithMessage("The telephone number provided is not a valid GR number. Check: 'https://en.wikipedia.org/wiki/Telephone_numbers_in_Greece'");

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
