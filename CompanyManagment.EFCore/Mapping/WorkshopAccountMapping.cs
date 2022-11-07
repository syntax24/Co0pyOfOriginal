using Company.Domain.WorkshopAccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class WorkshopAccountMapping : IEntityTypeConfiguration<WorkshopAccount>
    {
        public void Configure(EntityTypeBuilder<WorkshopAccount> builder)
        {
            builder.ToTable("WorkshopeAccounts");
            builder.HasKey(x => new { x.WorkshopId, x.AccountId });

            //builder.HasOne(x => x.Workshop)
            //    .WithMany(x => x.WorkshopAccounts)
            //    .HasForeignKey(x => x.WorkshopId);
            //builder.HasOne(x => x.Accounts)
            //    .WithMany(x => x.WorkshopAccounts)
            //    .HasForeignKey(x => x.WorkshopId);
        }
    }
}
