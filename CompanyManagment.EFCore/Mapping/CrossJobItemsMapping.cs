using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.CrossJobAgg;
using Company.Domain.CrossJobItemsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class CrossJobItemsMapping : IEntityTypeConfiguration<CrossJobItems>
    {
        public void Configure(EntityTypeBuilder<CrossJobItems> builder)
        {
            builder.ToTable("CrossJobItems");
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.CrossJob)
                .WithMany(x => x.CrossJobItemsList)
                .HasForeignKey(x => x.CrossJobId);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.CrossJobItemsList)
                .HasForeignKey(x => x.JobId);


        }


    }
}
