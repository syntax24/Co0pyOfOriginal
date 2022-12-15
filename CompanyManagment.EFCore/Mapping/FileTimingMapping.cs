
using Company.Domain.FileTiming;
using CompanyManagment.App.Contracts.FileTiming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CompanyManagment.EFCore.Mapping
{
    public class FileTimingMapping : IEntityTypeConfiguration<FileTiming>
    {
        public void Configure(EntityTypeBuilder<FileTiming> builder)
        {
            builder.ToTable("File_Timings");
            builder.HasKey(x => x.id);

            builder.HasMany(x => x.FileStates).WithOne(x => x.FileTiming).HasForeignKey(x => x.FileTiming_Id);

            builder.HasData(
                new { id = (long) 1, Deadline = 1, Title = "ثبت اولیه در سیستم", Tips= "	پس از مراجعه موکل و ثبت اولیه پرونده در نرم افزار ، در صورتی که تا پایان زمان مندرج در کادر ، موکل پرونده را تعیین و تکلیف ننماید و شما قادر به ورود به پرونده نباشید ، نرم افزار به شما گزارش میدهد . ", CreationDate = DateTime.Now },
                new { id = (long) 2, Deadline = 1, Title = "انتظار برای دریافت دعوتنامه اول", Tips= "	پس از ارائه دادخواست توسط شما یا موکل ، اگر تا پایان مهلت مندرج در این کادر ، دعوتنامه ای صادر نشده باشد ، نرم افزار به شما گزارش میدهد . ", CreationDate = DateTime.Now },
                new { id = (long) 3, Deadline = 1, Title = "انتظار برای دریافت دعوتنامه دوم به بعد یا دادنامه", Tips= "	پس از شرکت در جلسه اول رسیدگی ، اگر تا پایان مهلت مندرج در کادر ، دعوتنامه جدید یا دادنامه صادر نشده باشد ، نرم افزار به شما گزارش میدهد . ", CreationDate = DateTime.Now },
                new { id = (long) 4, Deadline = 1, Title = "مهلت اعتراض به دادنامه", Tips= "	پس از صدور دادنامه ، تا قبل از پایان مدت اعتراض مندرج در کادر ، اخطار مهلت اعتراض را نرم افزار به شما گزارش میدهد تا در فرصت مقرر اقدام به ثبت اعتراض نمائید . بدیهیست در صورت عدم ثبت اعتراض در مهلت مقرر دادنامه شما قطعی خواهد شد . ", CreationDate = DateTime.Now },
                new { id = (long) 5, Deadline = 1, Title = "انتظار برای دریافت دعوتنامه پس از اعتراض", Tips= "پس از ثبت اعتراض ، در صورتی که تا پایان مهلت مندرج در کادر ، دعوتنامه ای برای شما صادر نگردد ، نرم افزار به شما گزارش میدهد . ", CreationDate = DateTime.Now },
                new { id = (long) 6, Deadline = 1, Title = "انتظار برای دریافت دعوتنامه دوم به بعد یا دادنامه", Tips= "پس از شرکت در جلسه اول رسیدگی ، اگر تا پایان مهلت مندرج در کادر ، دعوتنامه جدید یا دادنامه صادر نشده باشد ، نرم افزار به شما گزارش میدهد .", CreationDate = DateTime.Now }
                );
        }
    }
}
