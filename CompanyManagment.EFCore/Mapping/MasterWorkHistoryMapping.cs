using Company.Domain.MasterWorkHistory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class MasterWorkHistoryMapping : IEntityTypeConfiguration<MasterWorkHistory>
    {
        public void Configure(EntityTypeBuilder<MasterWorkHistory> builder)
        {
            builder.ToTable("Master_WorkHistories");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.MasterPetition).WithMany(x => x.MasterWorkHistoriesList).HasForeignKey(x => x.MasterPetition_Id);
        }
    }
}
