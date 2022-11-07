using Company.Domain.YearlysSalaryTitleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class YearlySalaryTitleMapping : IEntityTypeConfiguration<YearlySalaryTitle>
    {
        public void Configure(EntityTypeBuilder<YearlySalaryTitle> builder)
        {

            builder.ToTable("YearlySalaryTitles");
            builder.HasKey(x => x.id);

            builder.Property(x => x.Title1).HasMaxLength(255);
            builder.Property(x => x.Title2).HasMaxLength(255);
            builder.Property(x => x.Title3).HasMaxLength(255);
            builder.Property(x => x.Title4).HasMaxLength(255);
            builder.Property(x => x.Title5).HasMaxLength(255);
            builder.Property(x => x.Title6).HasMaxLength(255);
            builder.Property(x => x.Title7).HasMaxLength(255);
            builder.Property(x => x.Title8).HasMaxLength(255);
            builder.Property(x => x.Title9).HasMaxLength(255);
            builder.Property(x => x.Title10).HasMaxLength(255);
        }
    }
}
