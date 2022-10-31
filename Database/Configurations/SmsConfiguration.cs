using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations
{
    public class SmsConfiguration : IEntityTypeConfiguration<Sms>
    {
        public void Configure(EntityTypeBuilder<Sms> builder)
        {
            builder.ToTable("Sms",
                t => t.HasCheckConstraint("Number_E.164", "[Number] like '+%[0-9]'"));

            builder.HasKey(m => m.Id)
                   .HasName("Id");

            builder.Property(e => e.Text)
                   .HasColumnName("Text")
                   .IsRequired();

            builder.Property(e => e.Number)
                   .HasColumnName("Number")
                   .IsRequired();

            builder.Property(e => e.DateSent)
                   .HasColumnName("DateSent")
                   .IsRequired();
        }
    }
}
