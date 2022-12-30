using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.HolidayItemAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class HolidayItemMapping : IEntityTypeConfiguration<HolidayItem>
    {
        public void Configure(EntityTypeBuilder<HolidayItem> builder)
        {
            builder.ToTable("Holidayitems");
            builder.HasKey(x => x.id);

            builder.Property(x => x.HolidayYear).HasMaxLength(4);

            builder.HasOne(x => x.Holidayss)
                .WithMany(x => x.HolidayItems)
                .HasForeignKey(x => x.HolidayId);
        }
    }
}
