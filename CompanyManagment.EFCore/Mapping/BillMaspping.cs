using Company.Domain.BillAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class BillMaspping : IEntityTypeConfiguration<EntityBill>
    {
        public void Configure(EntityTypeBuilder<EntityBill> builder)
        {
            builder.ToTable("TextManager_Bill");
            builder.HasKey(x => x.id);
            builder.Property(x => x.SubjectBill);
            builder.Property(x => x.Description);
            builder.Property(x => x.SubjectBill).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ProcessingStage);
            builder.Property(x => x.Contact);
            builder.Property(x => x.Appointed);
    
        }
    }
}
