using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsVendors.Vendors.GR
{
    public class SmsValidatorGR : SmsValidatorBase
    {
        private readonly int minGreekCharacter = 0x37e;
        private readonly int maxGreekCharacter = 0x3ce;

        public SmsValidatorGR() : base()
        {
            RuleFor(m => m.Text).Must(m => IsInGreek(m));
        }

        private bool IsInGreek(string text) => text.All(c => IsGreekNumberSymbol(c));

        private bool IsGreekNumberSymbol(char c)
        {
            return (c < minGreekCharacter || c > maxGreekCharacter) && !char.IsLetter(c);
        }

    }


}
