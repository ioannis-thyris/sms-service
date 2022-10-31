using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Database.AppContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Sms> Sms { get; set; }

    }
}
