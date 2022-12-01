using Company.Domain.EvidenceDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class EvidenceDetailMapping : IEntityTypeConfiguration<EvidenceDetail>
    {
        public void Configure(EntityTypeBuilder<EvidenceDetail> builder)
        {
            builder.ToTable("EvidenceDetails");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.Evidence).WithMany(x => x.EvidenceDetailsList).HasForeignKey(x => x.Evidence_Id);
        }
    }
}
