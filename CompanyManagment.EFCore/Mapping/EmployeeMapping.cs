using Company.Domain.EmployeeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.id);

            builder.Property(x => x.FName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Gender).HasMaxLength(10).IsRequired();
            builder.Property(x => x.NationalCode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.IdNumber).HasMaxLength(20);
            builder.Property(x => x.Nationality).HasMaxLength(50).IsRequired();
            builder.Property(x => x.FatherName).HasMaxLength(255);
            builder.Property(x => x.DateOfBirth);
            builder.Property(x => x.DateOfIssue);
            builder.Property(x => x.PlaceOfIssue).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.IsActiveString).HasMaxLength(10);
            builder.Property(x => x.MaritalStatus).HasMaxLength(10);
            builder.Property(x => x.MilitaryService).HasMaxLength(100);
            builder.Property(x => x.LevelOfEducation).HasMaxLength(100);
            builder.Property(x => x.FieldOfStudy).HasMaxLength(255);
            builder.Property(x => x.BankCardNumber).HasMaxLength(50);
            builder.Property(x => x.BankBranch).HasMaxLength(100);
            builder.Property(x => x.InsuranceCode).HasMaxLength(10);
            builder.Property(x => x.InsuranceHistoryByYear).HasMaxLength(10);
            builder.Property(x => x.InsuranceHistoryByMonth).HasMaxLength(10);
            builder.Property(x => x.NumberOfChildren).HasMaxLength(10);
            builder.Property(x => x.OfficePhone).HasMaxLength(50);




            builder.HasMany(x => x.EmployeeChildrenList)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId);

            builder.HasMany(x => x.Contracts)
                .WithOne(x => x.Employee)
                .HasForeignKey(x => x.EmployeeId);


        }

       
    }
}
