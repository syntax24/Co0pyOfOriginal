
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Company.Domain.BoardType;

namespace CompanyManagment.EFCore.Mapping
{
    public class BoardTypeMapping : IEntityTypeConfiguration<BoardType>
    {
        public void Configure(EntityTypeBuilder<BoardType> builder)
        {
            builder.ToTable("BoardTypes");
            builder.HasKey(x => x.Id);

           //builder.HasData(
           //     new { Id = 1, Title = "تشخیص" },
           //     new { Id = 1, Title = "حل اختلاف" }
           // );

        }
    }
}
