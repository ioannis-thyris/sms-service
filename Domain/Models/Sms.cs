using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sms
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Number { get; set; }
        public DateTime DateSent { get; set; } = DateTime.Now;

        public Sms()
        {

        }

        public Sms(Sms sms, string newText)
        {
            Id = sms.Id;
            Text = newText;
            Number = sms.Number;
            DateSent = sms.DateSent;
        }

    }
}
