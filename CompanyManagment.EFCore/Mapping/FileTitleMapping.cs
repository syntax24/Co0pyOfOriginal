
using Company.Domain.FileTitle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class FileTitleMapping : IEntityTypeConfiguration<FileTitle>
    {
        public void Configure(EntityTypeBuilder<FileTitle> builder)
        {
            builder.ToTable("File_Titles");
            builder.HasKey(x => x.id);

        }
    }
}
