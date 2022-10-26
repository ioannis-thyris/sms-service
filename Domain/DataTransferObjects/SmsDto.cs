using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public class SmsDto
    {
        public string Text { get; set; }
        public string Number { get; set; }
    }
}
