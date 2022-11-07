using Company.Domain.YearlySalaryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class YearlySalaryMapping : IEntityTypeConfiguration<YearlySalary>
    {
        public void Configure(EntityTypeBuilder<YearlySalary> builder)
        {
            builder.ToTable("YearlySalariess");
            builder.HasKey(x => x.id);

            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.Year).HasMaxLength(10);

            builder.HasMany(x => x.YearlySalaryItemsList)
                .WithOne(x => x.YearlySalary)
                .HasForeignKey(x => x.YearlySalaryId);

            builder.HasMany(x => x.Contracts)
                .WithOne(x => x.YearlySalary)
                .HasForeignKey(x => x.YearlySalaryId);

        }
    }
}
