using Company.Domain.MandatoryHoursAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class MandatoryHoursMapping :IEntityTypeConfiguration<MandatoryHours>
    {
        public void Configure(EntityTypeBuilder<MandatoryHours> builder)
        {
            builder.ToTable("MandatoryHours");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Year).HasMaxLength(4);
        }
    }
}
