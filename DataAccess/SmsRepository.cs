using Database.AppContext;
using Domain.Models;

namespace DataAccessLayer
{
    public class SmsRepository : ISmsRepository
    {
        private readonly Context _db;

        public SmsRepository(Context db)
        {
            _db = db;
        }

        public async Task<bool> Create(Sms sms)
        {
            await _db.Sms.AddAsync(sms);

            var state = _db.Entry(sms).State;

            await _db.SaveChangesAsync();

            return state == Microsoft.EntityFrameworkCore.EntityState.Added;
        }
    }
}
