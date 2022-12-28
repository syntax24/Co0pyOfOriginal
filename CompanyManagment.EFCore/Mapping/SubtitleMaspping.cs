using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Company.Domain.SubtitleAgg;

namespace CompanyManagment.EFCore.Mapping
{
    public class SubtitleMaspping : IEntityTypeConfiguration<EntitySubtitle>
    {
        public void Configure(EntityTypeBuilder<EntitySubtitle> builder)
        {
            builder.ToTable("TextManager_Subtitle");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Subtitle).HasMaxLength(60).IsRequired();

            builder.HasOne(x => x.EntityOriginalTitle)
              .WithMany(x => x.Subtitles)
              .HasForeignKey(x => x.OriginalTitle_Id);
        }
    }
}
