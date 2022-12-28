using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.EmployeeChildrenAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class EmployeeChildrenMapping : IEntityTypeConfiguration<EmployeeChildren>
    {
        public void Configure(EntityTypeBuilder<EmployeeChildren> builder)
        {
            builder.ToTable("EmployeeChildren");
            builder.HasKey(x => x.id);

            builder.Property(x => x.FName).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.ParentNationalCode).HasMaxLength(10);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeChildrenList)
                .HasForeignKey(x => x.EmployeeId);

        }
    }
}
