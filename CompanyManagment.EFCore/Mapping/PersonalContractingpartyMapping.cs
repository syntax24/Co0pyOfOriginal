using Company.Domain.ContarctingPartyAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class PersonalContractingpartyMapping : IEntityTypeConfiguration<PersonalContractingParty>
    {
        public void Configure(EntityTypeBuilder<PersonalContractingParty> builder)
        {
            builder.ToTable("PersonalContractingParties");
            builder.HasKey(x => x.id);

            //builder.Property(x => x.LegalName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.FName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Nationalcode).HasMaxLength(10).IsRequired();
            builder.Property(x => x.IdNumber).HasMaxLength(20).IsRequired();
            builder.Property(x => x.RegisterId).HasMaxLength(15).IsRequired();
            builder.Property(x => x.NationalId).HasMaxLength(15).IsRequired();
            builder.Property(x => x.IsLegal).HasMaxLength(10).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.AgentPhone).HasMaxLength(50);

            builder.HasMany(x => x.Employers)
                .WithOne(x => x.ContractingParty)
                .HasForeignKey(x => x.ContractingPartyId);

        }
    }
}
