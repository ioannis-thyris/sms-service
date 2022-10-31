using Domain.Models;

namespace DataAccessLayer
{
    public interface ISmsRepository
    {
        public Task<bool> Create(Sms sms);
    }
}
