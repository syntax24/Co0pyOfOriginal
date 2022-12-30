using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.WorkingHoursItemsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class WorkinHoursItemsMapping :IEntityTypeConfiguration<WorkingHoursItems>
    {
        public void Configure(EntityTypeBuilder<WorkingHoursItems> builder)
        {
            builder.ToTable("WorkingHoursItems");
            builder.HasKey(x => x.id);

            builder.Property(x => x.DayOfWork).HasMaxLength(1);
            builder.Property(x => x.ComplexStart).HasMaxLength(5);
            builder.Property(x => x.ComplexEnd).HasMaxLength(5);
            builder.Property(x => x.RestTime).HasMaxLength(2);
            builder.Property(x => x.Start1).HasMaxLength(5);
            builder.Property(x => x.End1).HasMaxLength(5);
            builder.Property(x => x.Start2).HasMaxLength(5);
            builder.Property(x => x.End2).HasMaxLength(5);
            builder.Property(x => x.Start3).HasMaxLength(5);
            builder.Property(x => x.End3).HasMaxLength(5);

            builder.HasOne(x=>x.WorkingHourses)
                .WithMany(x=>x.WorkingHoursItemsList)
                .HasForeignKey(x=>x.WorkingHoursId);
        }
    }
}
