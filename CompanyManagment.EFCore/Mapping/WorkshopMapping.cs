using System;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    partial class WorkshopMapping : IEntityTypeConfiguration<Workshop>
    {
        public void Configure(EntityTypeBuilder<Workshop> builder)
        {
            builder.ToTable("Workshops");
            builder.HasKey(x => x.id);

            builder.Property(x => x.WorkshopName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.WorkshopSureName).HasMaxLength(255);
            builder.Property(x => x.WorkshopFullName).HasMaxLength(255);
            builder.Property(x => x.InsuranceCode).HasMaxLength(100);
            builder.Property(x => x.TypeOfOwnership).HasMaxLength(100);
            builder.Property(x => x.ArchiveCode).HasMaxLength(100);
            builder.Property(x => x.AgentName).HasMaxLength(100);
            builder.Property(x => x.AgentPhone).HasMaxLength(50);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.TypeOfInsuranceSend).HasMaxLength(100);
            builder.Property(x => x.TypeOfContract).HasMaxLength(100);
            builder.Property(x => x.IsActiveString).HasMaxLength(10);
            builder.Property(x => x.ContractTerm).HasMaxLength(10);

            //builder.HasOne(x => x.Employer)
            //    .WithMany(x => x.Workshops)
            //    .HasForeignKey(x => x.EmployerId);
            builder.HasMany(x => x.LeftWorks)
                .WithOne(x => x.Workshop)
                .HasForeignKey(x => x.WorkshopId);

            builder.HasMany(x => x.Contracts2)
                .WithOne(x => x.Workshop)
                .HasForeignKey(x => x.WorkshopIds)
                .OnDelete(DeleteBehavior.NoAction);




        }
    }
}
