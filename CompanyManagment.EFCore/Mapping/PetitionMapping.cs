
using Company.Domain.Petition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class PetitionMapping : IEntityTypeConfiguration<Petition>
    {
        public void Configure(EntityTypeBuilder<Petition> builder)
        {
            builder.ToTable("Petitions");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.File1).WithMany(x => x.PetitionsList).HasForeignKey(x => x.File_Id);
            builder.HasOne(x => x.BoardType).WithMany(x => x.PetitionsList).HasForeignKey(x => x.BoardType_Id);
            builder.HasMany(x => x.WorkHistoriesList).WithOne(x => x.Petition).HasForeignKey(x => x.Petition_Id);
            builder.HasMany(x => x.PenaltyTitlesList).WithOne(x => x.Petition).HasForeignKey(x => x.Petition_Id);
        }
    }
}
