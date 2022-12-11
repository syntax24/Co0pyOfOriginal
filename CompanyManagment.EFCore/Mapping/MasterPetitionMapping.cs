
using Company.Domain.MasterPetition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class MasterPetitionMapping : IEntityTypeConfiguration<MasterPetition>
    {
        public void Configure(EntityTypeBuilder<MasterPetition> builder)
        {
            builder.ToTable("Master_Petitions");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.File1).WithMany(x => x.MasterPetitionsList).HasForeignKey(x => x.File_Id);
            builder.HasOne(x => x.BoardType).WithMany(x => x.MasterPetitionsList).HasForeignKey(x => x.BoardType_Id);
            builder.HasMany(x => x.MasterWorkHistoriesList).WithOne(x => x.MasterPetition).HasForeignKey(x => x.MasterPetition_Id);
            builder.HasMany(x => x.MasterPenaltyTitlesList).WithOne(x => x.MasterPetition).HasForeignKey(x => x.MasterPetition_Id);
        }
    }
}
