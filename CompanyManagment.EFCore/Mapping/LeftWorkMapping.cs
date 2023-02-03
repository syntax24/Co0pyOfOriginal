using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.LeftWorkAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class LeftWorkMapping : IEntityTypeConfiguration<LeftWork>
    {
        public void Configure(EntityTypeBuilder<LeftWork> builder)
        {
            builder.ToTable("LeftWork");
            builder.HasKey(x => x.id);

            builder.Property(x => x.EmployeeFullName).HasMaxLength(255);
            builder.Property(x => x.WorkshopName).HasMaxLength(255);


            builder.HasOne(x => x.Employee)
                .WithMany(x => x.LeftWorks)
                .HasForeignKey(x => x.EmployeeId);
            builder.HasOne(x => x.Workshop)
                .WithMany(x => x.LeftWorks)
                .HasForeignKey(x => x.WorkshopId);


        }
    }
}
