
using Company.Domain.FileState;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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

            builder.HasData(
                new { id = (long) 1, State = 1, FileTiming_Id = (long) 1, Title = "کلاسه پرونده ثبت نشده است", CreationDate = DateTime.Now },
                new { id = (long) 2, State = 2, FileTiming_Id = (long) 1, Title = "وکالت نامه پرونده ثبت نشده است", CreationDate = DateTime.Now },
                new { id = (long) 3, State = 3, FileTiming_Id = (long) 2, Title = "دعوتنامه ای برای جلسات دادگاه تشخیص صادر نشده است", CreationDate = DateTime.Now },
                new { id = (long) 4, State = 4, FileTiming_Id = (long) 3, Title = "دعوتنامه جدید یا دادنامه تشخیص صادر نشده است", CreationDate = DateTime.Now },
                new { id = (long) 5, State = 5, FileTiming_Id = (long) 4, Title = "اعتراض برای پرونده ثبت نشده است", CreationDate = DateTime.Now },
                new { id = (long) 6, State = 6, FileTiming_Id = (long) 5, Title = "دعوتنامه ای برای جلسات دادگاه تجدیدنظر صادر نشده است", CreationDate = DateTime.Now },
                new { id = (long) 7, State = 7, FileTiming_Id = (long) 6, Title = "دعوتنامه جدید یا دادنامه تجدیدنظر صادر نشده است", CreationDate = DateTime.Now }
                );
        }
    }
}



