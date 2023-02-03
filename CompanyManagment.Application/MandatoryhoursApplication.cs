using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.MandatoryHoursAgg;
using CompanyManagment.App.Contracts.MandantoryHours;

namespace CompanyManagment.Application
{
    public class MandatoryHoursApplication : IMandatoryHoursApplication
    {
        private readonly IMandatoryHoursRepository _mandatoryHoursRepository;

        public MandatoryHoursApplication(IMandatoryHoursRepository mandatoryHoursRepository)
        {
            _mandatoryHoursRepository = mandatoryHoursRepository;
        }


        public OperationResult Create(CreateMandatoryHours command)
        {
            var operation = new OperationResult();
            if(_mandatoryHoursRepository.Exists(x=>x.Year == command.Year))
                return operation.Failed("سال وارد شده تکراری است");
            var mandatory = new MandatoryHours(command.Year, command.Farvardin, command.Ordibehesht, command.Khordad,
                command.Tir, command.Mordad, command.Shahrivar, command.Mehr, command.Aban,
                command.Azar, command.Dey, command.Bahman, command.Esfand);
            _mandatoryHoursRepository.Create(mandatory);
            _mandatoryHoursRepository.SaveChanges();
            return operation.Succcedded();
        }

        public OperationResult Edit(EditMandatoryHours command)
        {
            var operation = new OperationResult();
            var mandatory = _mandatoryHoursRepository.Get(command.Id);
            if (mandatory == null)
                operation.Failed("رکورد مورد نظر وجود ندارد");

            if (_mandatoryHoursRepository.Exists(x => x.Year == command.Year && x.id != command.Id))
                return operation.Failed("سال وارد شده تکراری است");

            mandatory.Edit(command.Year, command.Farvardin, command.Ordibehesht, command.Khordad,
                command.Tir, command.Mordad, command.Shahrivar, command.Mehr, command.Aban,
                command.Azar, command.Dey, command.Bahman, command.Esfand);
            _mandatoryHoursRepository.SaveChanges();
            return operation.Succcedded();
        }

        public EditMandatoryHours GetDetails(long id)
        {
            return _mandatoryHoursRepository.GetDetails(id);
        }

        public List<MandatoryHoursViewModel> GetMandatoryHours()
        {
            return _mandatoryHoursRepository.GetMandatoryHours();
        }

        public List<MandatoryHoursViewModel> Search(MandatoryHoursSearchModel searchModel)
        {
            return _mandatoryHoursRepository.Search(searchModel);
        }
    }
}
