using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.ContractAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class ContractMapping : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable("Contracts");
            builder.HasKey(x => x.id);

            builder.Property(x => x.ContractNo).HasMaxLength(255);
            builder.Property(x => x.ArchiveCode).HasMaxLength(255);
            builder.Property(x => x.IsActiveString).HasMaxLength(10);
            builder.Property(x => x.WorkshopAddress1).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.WorkshopAddress2).HasMaxLength(500).IsRequired(false);
            builder.Property(x => x.ContractType).HasMaxLength(20);
            builder.Property(x => x.JobType).HasMaxLength(100);
            builder.Property(x => x.DayliWage).HasMaxLength(50);
            builder.Property(x => x.ConsumableItems).HasMaxLength(50);
            builder.Property(x => x.HousingAllowance).HasMaxLength(50);
            builder.Property(x => x.WorkingHoursWeekly).HasMaxLength(10);
            builder.Property(x => x.FamilyAllowance).HasMaxLength(100);
            builder.Property(x => x.ContractPeriod).HasMaxLength(2).IsRequired(false);
            builder.Property(x => x.AgreementSalary).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Signature).HasMaxLength(1).IsRequired(false);






            builder.HasOne(x => x.Workshop)
                .WithMany(x => x.Contracts2)
                .HasForeignKey(x => x.WorkshopIds);
            builder.HasOne(x => x.Employer)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.EmployerId);
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.EmployeeId);
           
            builder.HasOne(x => x.YearlySalary)
                .WithMany(x => x.Contracts)
                .HasForeignKey(x => x.YearlySalaryId);

            builder.HasOne(x => x.Job)
                .WithMany(x => x.ContractsList)
                .HasForeignKey(x => x.JobTypeId);

            builder.HasMany(x => x.WorkingHoursList)
                .WithOne(x => x.Contracts)
                .HasForeignKey(x => x.ContractId);

        }
    }
}
