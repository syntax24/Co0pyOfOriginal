using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.CrossJobAgg;
using Company.Domain.CrossJobGuildAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class CrossJobMapping : IEntityTypeConfiguration<CrossJob>
    {
        public void Configure(EntityTypeBuilder<CrossJob> builder)
        {
            builder.ToTable("CrossJobs");
            builder.HasKey(x => x.id);

            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.SalaryRatioOver).IsRequired();
            builder.Property(x => x.SalaryRatioUnder).IsRequired();
            builder.Property(x => x.EquivalentRialOver).IsRequired();
            builder.Property(x => x.EquivalentRialUnder).IsRequired();



            builder.HasOne(x => x.CrossJobGuild)
                .WithMany(x => x.CrossJobList)
                .HasForeignKey(x => x.CrossJobGuildId);


        }

       
    }
}
