using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.InfraStructure;
using Company.Domain.MandatoryHoursAgg;
using CompanyManagment.App.Contracts.MandantoryHours;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class MandatoryHoursRepository : RepositoryBase<long, MandatoryHours>, IMandatoryHoursRepository
    {
        private readonly CompanyContext _context;
        public MandatoryHoursRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<MandatoryHoursViewModel> GetMandatoryHours()
        {
            return _context.MandatoryHoursDbSet.Select(x=> new MandatoryHoursViewModel
            {
                Id = x.id,
                Year = x.Year,
                Farvardin = x.Farvardin,
                Ordibehesht = x.Ordibehesht,
                Khordad = x.Khordad,
                Tir = x.Tir,
                Mordad = x.Mordad,
                Shahrivar = x.Shahrivar,
                Mehr = x.Mehr,
                Aban = x.Aban,
                Azar = x.Azar,
                Dey = x.Dey,
                Bahman = x.Bahman,
                Esfand = x.Esfand


            }).ToList();
        }

        public EditMandatoryHours GetDetails(long id)
        {
            return _context.MandatoryHoursDbSet.Select(x => new EditMandatoryHours
            {
                Id = x.id,
                Year = x.Year,
                Farvardin = x.Farvardin,
                Ordibehesht = x.Ordibehesht,
                Khordad = x.Khordad,
                Tir = x.Tir,
                Mordad = x.Mordad,
                Shahrivar = x.Shahrivar,
                Mehr = x.Mehr,
                Aban = x.Aban,
                Azar = x.Azar,
                Dey = x.Dey,
                Bahman = x.Bahman,
                Esfand = x.Esfand


            }).FirstOrDefault(x => x.Id == id); 
        }

        public List<MandatoryHoursViewModel> Search(MandatoryHoursSearchModel searchModel)
        {
            var query = _context.MandatoryHoursDbSet.Select(x => new MandatoryHoursViewModel
            {
                Id = x.id,
                Year = x.Year,
                Farvardin = x.Farvardin,
                Ordibehesht = x.Ordibehesht,
                Khordad = x.Khordad,
                Tir = x.Tir,
                Mordad = x.Mordad,
                Shahrivar = x.Shahrivar,
                Mehr = x.Mehr,
                Aban = x.Aban,
                Azar = x.Azar,
                Dey = x.Dey,
                Bahman = x.Bahman,
                Esfand = x.Esfand

            });
            if (searchModel.Year > 0)
                query = query.Where(x => x.Year==searchModel.Year);
            return query.OrderByDescending(x => x.Year).ToList();
        }
    }
}
