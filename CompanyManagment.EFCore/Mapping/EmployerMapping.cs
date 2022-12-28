using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.empolyerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class EmployerMapping :IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employers");
            builder.HasKey(x => x.id);

            builder.Property(x => x.FName).HasMaxLength(255);
            builder.Property(x => x.LName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(255);
            builder.Property(x => x.Gender).HasMaxLength(10);
            builder.Property(x => x.Nationalcode).HasMaxLength(10);
            builder.Property(x => x.IdNumber).HasMaxLength(20);
            builder.Property(x => x.Nationality).HasMaxLength(50);
            builder.Property(x => x.FatherName).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.DateOfIssue);
            builder.Property(x => x.PlaceOfIssue).HasMaxLength(50);
            builder.Property(x => x.EmployerLName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.RegisterId).HasMaxLength(15);
            builder.Property(x => x.NationalId).HasMaxLength(15);
            builder.Property(x => x.IsLegal).HasMaxLength(10);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.AgentPhone).HasMaxLength(50);
            builder.Property(x => x.MclsUserName).HasMaxLength(100);
            builder.Property(x => x.MclsPassword).HasMaxLength(100);
            builder.Property(x => x.EserviceUserName).HasMaxLength(100);
            builder.Property(x => x.EservicePassword).HasMaxLength(100);
            builder.Property(x => x.TaxOfficeUserName).HasMaxLength(100);
            builder.Property(x => x.TaxOfficepassword).HasMaxLength(100);
            builder.Property(x => x.SanaUserName).HasMaxLength(100);
            builder.Property(x => x.SanaPassword).HasMaxLength(100);
            builder.Property(x => x.EmployerNo).HasMaxLength(100);

            builder.HasOne(x => x.ContractingParty)
                .WithMany(x => x.Employers)
                .HasForeignKey(x => x.ContractingPartyId);

            //builder.HasMany(x => x.Workshops)
            //    .WithOne(x => x.Employer)
            //    .HasForeignKey(x => x.EmployerId);

            builder.HasMany(x => x.Contracts)
                .WithOne(x => x.Employer)
                .HasForeignKey(x => x.EmployerId);

        }
    }
}
