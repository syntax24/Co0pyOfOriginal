using Company.Domain.WorkingHoursAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class WorkingHoursMapping : IEntityTypeConfiguration<WorkingHours>
    {
        public void Configure(EntityTypeBuilder<WorkingHours> builder)
        {
            builder.ToTable("WorkingHours");
            builder.HasKey(x => x.id);

            builder.Property(x => x.ShiftWork).HasMaxLength(2);
            builder.Property(x => x.ContractNo).HasMaxLength(100);
            builder.Property(x => x.NumberOfWorkingDays).HasMaxLength(15);
            builder.Property(x => x.NumberOfFriday).HasMaxLength(15);
            builder.Property(x => x.ContractNo).HasMaxLength(100);
            builder.Property(x => x.OverNightWorkH).HasMaxLength(10);
            builder.Property(x => x.OverNightWorkM).HasMaxLength(2);
            builder.Property(x => x.ContractNo).HasMaxLength(100);
            builder.Property(x => x.OverTimeWorkH).HasMaxLength(15);
            builder.Property(x => x.OverTimeWorkM).HasMaxLength(2);
            builder.Property(x => x.TotalHoursesH).HasMaxLength(15);
            builder.Property(x => x.TotalHoursesM).HasMaxLength(2);
            builder.Property(x => x.WeeklyWorkingTime).HasMaxLength(10);

            builder.HasOne(x => x.Contracts)
                .WithMany(x => x.WorkingHoursList)
                .HasForeignKey(x => x.ContractId);

            builder.HasMany(x => x.WorkingHoursItemsList)
                .WithOne(x => x.WorkingHourses)
                .HasForeignKey(x => x.WorkingHoursId);


        }
    }
}
