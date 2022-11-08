using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Company.Domain.ChapterAgg;

namespace CompanyManagment.EFCore.Mapping
{
    public class ChapterMaspping : IEntityTypeConfiguration<EntityChapter>
    {
        public void Configure(EntityTypeBuilder<EntityChapter> builder)
        {
            builder.ToTable("TextManager_Chapter");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Chapter).HasMaxLength(60).IsRequired();

            builder.HasOne(x => x.EntitySubtitle)
              .WithMany(x => x.Chapters)
              .HasForeignKey(x => x.Subtitle_Id);
        }
    }
}
