using Company.Domain.MasterPenaltyTitle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class MasterPenaltyTitleMapping : IEntityTypeConfiguration<MasterPenaltyTitle>
    {
        public void Configure(EntityTypeBuilder<MasterPenaltyTitle> builder)
        {
            builder.ToTable("Master_PenaltyTitles");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.MasterPetition).WithMany(x => x.MasterPenaltyTitlesList).HasForeignKey(x => x.MasterPetition_Id);
        }
    }
}
