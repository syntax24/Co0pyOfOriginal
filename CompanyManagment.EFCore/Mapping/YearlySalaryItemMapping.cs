using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.YearlySalaryItemsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class YearlySalaryItemMapping : IEntityTypeConfiguration<YearlySalaryItem>
    {
        public void Configure(EntityTypeBuilder<YearlySalaryItem> builder)
        {
            builder.ToTable("YearlyItems");
            builder.HasKey(x => x.id);

            builder.Property(x => x.ItemName).HasMaxLength(255);
            builder.Property(x => x.ValueType).HasMaxLength(10);

            builder.HasOne(x => x.YearlySalary)
                .WithMany(x => x.YearlySalaryItemsList)
                .HasForeignKey(x => x.YearlySalaryId);

        }
    }
}
