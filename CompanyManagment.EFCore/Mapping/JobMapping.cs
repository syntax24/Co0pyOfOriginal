using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.JobAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class JobMapping : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            builder.HasKey(x => x.id);

            builder.Property(x => x.JobName).HasMaxLength(255);
            builder.Property(x => x.JobCode).HasMaxLength(100);

            builder.HasMany(x => x.ContractsList)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobTypeId);
        }
    }
}
