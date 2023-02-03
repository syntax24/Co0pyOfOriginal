using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class FileMapping : IEntityTypeConfiguration<Company.Domain.File1.File1>
    {

        public void Configure(EntityTypeBuilder<Company.Domain.File1.File1> builder)
        {
            builder.ToTable("Files");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasMany(x => x.BoardsList).WithOne(x => x.File1).HasForeignKey(x => x.File_Id);
            builder.HasMany(x => x.PetitionsList).WithOne(x => x.File1).HasForeignKey(x => x.File_Id);
            builder.HasMany(x => x.FileAlertsList).WithOne(x => x.File).HasForeignKey(x => x.File_Id);
        }
    }
}
