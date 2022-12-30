using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.HolidayAgg;
using CompanyManagment.App.Contracts.Holiday;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class HolidayRepository : RepositoryBase<long, Holiday>, IHolidayRepository
    {
        private readonly CompanyContext _context;

        public HolidayRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }


        public List<HolidayViewModel> GetHoliday()
        {
            return _context.Holidays.Select(x => new HolidayViewModel
            {
                Id = x.id,
                Year = x.Year,
               

            }).ToList();
        }

        public EditHoliday GetDetails(long id)
        {
            return _context.Holidays.Select(x => new EditHoliday
                {
                    Id = x.id,
                    Year = x.Year



                })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<HolidayViewModel> Search(HolidaySearchModel searchModel)
        {
            var query = _context.Holidays.Select(x => new HolidayViewModel
            {
                Id = x.id,

                Year = x.Year

            });

            if (!string.IsNullOrWhiteSpace(searchModel.Year))
                query = query.Where(x => x.Year.Contains(searchModel.Year));
            

            return query.OrderByDescending(x => x.Year).ToList();
        }
    }
}
