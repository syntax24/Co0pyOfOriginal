using Company.Domain.TextManagerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class TextManagerMaspping : IEntityTypeConfiguration<EntityTextManager>
    {
        public void Configure(EntityTypeBuilder<EntityTextManager> builder)
        {
            builder.ToTable("TextManager_TextManager");
            builder.HasKey(x => x.id);
            builder.Property(x => x.NoteNumber);
            builder.Property(x => x.NumberTextManager);
            builder.Property(x => x.Paragraph).HasMaxLength(500).IsRequired();
           }
    }
}
