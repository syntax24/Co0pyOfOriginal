using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.LeaveAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class LeaveMapping : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ToTable("Leave");
            builder.HasKey(x => x.id);

            builder.Property(x => x.LeaveHourses).HasMaxLength(5);
            builder.Property(x => x.PaidLeaveType).HasMaxLength(25);
            builder.Property(x => x.LeaveType).HasMaxLength(25);
            builder.Property(x => x.EmployeeFullName).HasMaxLength(255);
            builder.Property(x => x.WorkshopName).HasMaxLength(255);
            
        }
    }
}
