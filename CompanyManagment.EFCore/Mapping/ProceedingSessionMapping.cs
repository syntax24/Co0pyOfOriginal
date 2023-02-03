
using Company.Domain.ProceedingSession;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyManagment.EFCore.Mapping
{
    public class ProceedingSessionMapping : IEntityTypeConfiguration<ProceedingSession>
    {
        public void Configure(EntityTypeBuilder<ProceedingSession> builder)
        {
            builder.ToTable("ProceedingSessions");
            builder.HasKey(x => x.id);

            //TODO
            //add validations

            builder.HasOne(x => x.Board).WithMany(x => x.ProceedingSessionsList).HasForeignKey(x => x.Board_Id);
        }
    }
}
