using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.WorkshopEmployerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class WorkshopEmployerMapping : IEntityTypeConfiguration<WorkshopEmployer>
    {
        public void Configure(EntityTypeBuilder<WorkshopEmployer> builder)
        {
            builder.ToTable("WorkshopeEmployers");
            builder.HasKey(x => new { x.WorkshopId, x.EmployerId });

            builder.HasOne(x => x.Workshop)
                .WithMany(x => x.WorkshopEmployers)
                .HasForeignKey(x => x.WorkshopId);
            builder.HasOne(x => x.Employer)
                .WithMany(x => x.WorkshopEmployers)
                .HasForeignKey(x => x.EmployerId);
        }
    }
}
