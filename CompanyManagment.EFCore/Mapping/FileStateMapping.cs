
using Company.Domain.FileState;
using CompanyManagment.App.Contracts.FileState;
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
                new { 
                        id = (long) FileStateEnums.FILE_CLASS_NOT_REGISTERED, 
                        State = FileStateEnums.FILE_CLASS_NOT_REGISTERED, 
                        FileTiming_Id = (long) 1,                         
                        Title = "کلاسه پرونده ثبت نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.MANDATE_NOT_REGISTERED, 
                        State = FileStateEnums.MANDATE_NOT_REGISTERED, 
                        FileTiming_Id = (long) 1,                         
                        Title = "وکالت نامه پرونده ثبت نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.NO_PETITION_DATE_ISSUED, 
                        State = FileStateEnums.NO_PETITION_DATE_ISSUED, 
                        FileTiming_Id = (long) 1,                         
                        Title = "تاریخ ثبت دادخواست ثبت نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.NO_DIAGNOSIS_INVITATION_ISSUED, 
                        State = FileStateEnums.NO_DIAGNOSIS_INVITATION_ISSUED, 
                        FileTiming_Id = (long) 2,                        
                        Title = "دعوتنامه ای برای جلسات دادگاه تشخیص صادر نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.NO_DIAGNOSIS_PETITION_ISSUED, 
                        State = FileStateEnums.NO_DIAGNOSIS_PETITION_ISSUED, 
                        FileTiming_Id = (long) 3,                         
                        Title = "دعوتنامه جدید یا دادنامه تشخیص صادر نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.PROTEST_NOT_REGISTERED, 
                        State = FileStateEnums.PROTEST_NOT_REGISTERED, 
                        FileTiming_Id = (long) 4,                        
                        Title = "اعتراض برای پرونده ثبت نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.NO_DISPUTE_INVITATION_ISSUED, 
                        State = FileStateEnums.NO_DISPUTE_INVITATION_ISSUED, 
                        FileTiming_Id = (long) 5, 
                        Title = "دعوتنامه ای برای جلسات دادگاه تجدیدنظر صادر نشده است", 
                        CreationDate = DateTime.Now 
                },
                new { 
                        id = (long) FileStateEnums.NO_DISPUTE_PETITION_ISSUED, 
                        State = FileStateEnums.NO_DISPUTE_PETITION_ISSUED, 
                        FileTiming_Id = (long) 6, 
                        Title = "دعوتنامه جدید یا دادنامه تجدیدنظر صادر نشده است", 
                        CreationDate = DateTime.Now 
                }
                );
        }
    }
}
//public const int FILE_CLASS_NOT_REGISTERED = 1;
//public const int MANDATE_NOT_REGISTERED = 2;
//public const int NO_DIAGNOSIS_INVITATION_ISSUED = 3;
//public const int NO_DIAGNOSIS_PETITION_ISSUED = 4;
//public const int PROTEST_NOT_REGISTERED = 5;
//public const int NO_DISPUTE_INVITATION_ISSUED = 6;
//public const int NO_DISPUTE_PETITION_ISSUED = 7;
//public const int NO_PETITION_DATE_ISSUED = 8;



