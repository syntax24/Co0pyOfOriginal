using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.YearlysSalaryTitleAgg;
using CompanyManagment.App.Contracts.YearlySalaryTitles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyManagment.EFCore.Repository
{
    public class YearlySalaryTitleRepository : RepositoryBase<long, YearlySalaryTitle>, IYearlySalaryTitleRepository
    {
        private readonly CompanyContext _context;
        public YearlySalaryTitleRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public EditTitle GetDetails(long id)
        {
            return _context.YearlySalaryTitles.Select(x => new EditTitle
            {
                Id = x.id,
                Title1 = x.Title1,
                Title2 = x.Title2,
                Title3 = x.Title3,
                Title4 = x.Title4,
                Title5 = x.Title5,
                Title6 = x.Title6,
                Title7 = x.Title7,
                Title8 = x.Title8,
                Title9 = x.Title9,
                Title10 = x.Title10






            }).FirstOrDefault(x => x.Id == id);
        }

        public List<TitleViewModel> Search(TitleSearchModel searchModel)
        {
            var query = _context.YearlySalaryTitles.Select(x => new TitleViewModel
            {
                Id = x.id,

                Title1 = x.Title1,
                Title2 = x.Title2,
                Title3 = x.Title3,
                Title4 = x.Title4,
                Title5 = x.Title5,
                Title6 = x.Title6,
                Title7 = x.Title7,
                Title8 = x.Title8,
                Title9 = x.Title9,
                Title10 = x.Title10


            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title1))
            {

                query = query.Where(x => x.Title1 == searchModel.Title1);
            }



            return query.OrderByDescending(x => x.Id).ToList();
        }

        public List<string> GetLast()
        {
            var titles = _context.YearlySalaryTitles.ToList();
            var x = titles.LastOrDefault();
            var query = new List<string>
            {
                x.Title1,
                x.Title2,
                x.Title3,
                x.Title4,
                x.Title5,
                x.Title6,
                x.Title7,
                x.Title8,
                x.Title9,
                x.Title10
            };
           
         


            return query;


        }
    }
}
