
using Company.Domain.FileAlert;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class FileAlertMapping : IEntityTypeConfiguration<FileAlert>
    {
        public void Configure(EntityTypeBuilder<FileAlert> builder)
        {
            builder.ToTable("File_Alerts");
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.File).WithMany(x => x.FileAlertsList).HasForeignKey(x => x.File_Id);
            builder.HasOne(x => x.FileState).WithMany(x => x.FileAlertsList).HasForeignKey(x => x.FileState_Id);
        }
    }
}
