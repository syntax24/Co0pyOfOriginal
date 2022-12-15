
using Company.Domain.FileState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class FileStateMapping : IEntityTypeConfiguration<FileState>
    {
        public void Configure(EntityTypeBuilder<FileState> builder)
        {
            builder.ToTable("File_States");
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.FileTiming).WithMany(x => x.FileStates).HasForeignKey(x => x.FileTiming_Id);
            builder.HasMany(x => x.FileAlertsList).WithOne(x => x.FileState).HasForeignKey(x => x.FileState_Id);
        }
    }
}
