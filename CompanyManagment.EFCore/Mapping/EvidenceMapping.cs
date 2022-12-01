
using Company.Domain.Evidence;
using Company.Domain.Petition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class EvidenceMapping : IEntityTypeConfiguration<Evidence>
    {
        public void Configure(EntityTypeBuilder<Evidence> builder)
        {
            builder.ToTable("Evidences");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.File1).WithMany(x => x.EvidencesList).HasForeignKey(x => x.File_Id);
            builder.HasOne(x => x.BoardType).WithMany(x => x.EvidencesList).HasForeignKey(x => x.BoardType_Id);
            builder.HasMany(x => x.EvidenceDetailsList).WithOne(x => x.Evidence).HasForeignKey(x => x.Evidence_Id);
        }
    }
}
