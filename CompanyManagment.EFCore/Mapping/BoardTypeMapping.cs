
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Domain.BoardType;

namespace CompanyManagment.EFCore.Mapping
{
    public class BoardTypeMapping : IEntityTypeConfiguration<BoardType>
    {
        public void Configure(EntityTypeBuilder<BoardType> builder)
        {
            builder.ToTable("BoardTypes");
            builder.HasKey(x => x.Id);

           // var boardType = new BoardType[2];
           // boardType[1].Title = "تشخیص";
           // boardType[2].Title = "حل اختلاف";

           //builder.HasData(boardType);

        }
    }
}
