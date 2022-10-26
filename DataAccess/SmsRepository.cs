using Database.AppContext;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SmsRepository : ISmsRepository
    {
        private readonly Context _db;

        public SmsRepository(Context db)
        {
            db = _db;
        }

        public async Task<Sms> Create(Sms sms)
        {
            await _db.Sms.AddAsync(sms);

            var test = _db.Entry(sms).State;

            await _db.SaveChangesAsync();

            var test2 = _db.Entry(sms).State;

            return sms;
        }
    }
}
