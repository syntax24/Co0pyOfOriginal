using Company.Domain.PenaltyTitle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class PenaltyTitleMapping : IEntityTypeConfiguration<PenaltyTitle>
    {
        public void Configure(EntityTypeBuilder<PenaltyTitle> builder)
        {
            builder.ToTable("PenaltyTitles");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.Petition).WithMany(x => x.PenaltyTitlesList).HasForeignKey(x => x.Petition_Id);
        }
    }
}
