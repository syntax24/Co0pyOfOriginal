using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Company.Domain.OriginalTitleAgg;

namespace CompanyManagment.EFCore.Mapping
{
    public class OriginalTitleMaspping : IEntityTypeConfiguration<EntityOriginalTitle>
    {
        public void Configure(EntityTypeBuilder<EntityOriginalTitle> builder)
        {
            builder.ToTable("TextManager_OriginalTitle");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Title).HasMaxLength(60).IsRequired();

            builder.HasMany(x => x.Subtitles)
                .WithOne(x => x.EntityOriginalTitle)
                .HasForeignKey(x => x.OriginalTitle_Id);
        }
    }
}
