using Company.Domain.HolidayAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class HolidayMapping : IEntityTypeConfiguration<Holiday>
    {
        public void Configure(EntityTypeBuilder<Holiday> builder)
        {
            builder.ToTable("Holidays");
            builder.HasKey(x => x.id);

            builder.Property(x => x.Year).HasMaxLength(4);

            builder.HasMany(x => x.HolidayItems)
                .WithOne(x => x.Holidayss)
                .HasForeignKey(x => x.HolidayId);
        }
    }
}
