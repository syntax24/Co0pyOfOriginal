using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using _0_Framework.Application;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;
using CompanyManagment.App.Contracts.Workshop;
using Microsoft.EntityFrameworkCore.Internal;

namespace CompanyManagment.Application
{
    public class WorkshopAppliction : IWorkshopApplication
    {
        private readonly IWorkshopRepository _workshopRepository;
       
        
        public WorkshopAppliction(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        public OperationResult Create(CreateWorkshop command)
        {
            var accountIds = new List<long>();
            var operation = new OperationResult();
            if (command.EmployerIdList==null)
                return operation.Failed("لطفا کارفرما را انتخاب نمایید");
            var employer = command.EmployerIdList.ToList();
            if (command.AccountIdsList != null)
            {
                accountIds = command.AccountIdsList.ToList();
            }
           
            
            if (_workshopRepository.Exists(x => x.WorkshopName == command.WorkshopName))
                return operation.Failed("نام کارگاه تکراری است");
            if (_workshopRepository.Exists(x => x.InsuranceCode != null && x.InsuranceCode == command.InsuranceCode))
                return operation.Failed("کد بیمه کارگاه تکراری است");
            if (command.Address != null && command.State == null)
                return operation.Failed("لطفا استان و شهر را انتخاب کنید");
            if ((command.Address != null && command.State != null) && command.City == "لطفا شهر را انتخاب نمایید")
                return operation.Failed("لطفا شهر را انتخاب کنید");
            if (command.Address == null && command.State != null)
                return operation.Failed("لطفا آدرس را وارد کنید");

            if (command.TypeOfInsuranceSend != null && command.InsuranceCode == null)
                return operation.Failed("لطفا کد بیمه کارگاه را وارد کنید");
               

            var workshop = new Workshop(command.WorkshopName, command.WorkshopSureName, command.InsuranceCode, 
                command.TypeOfOwnership,
                command.ArchiveCode, command.AgentName, command.AgentPhone, command.State, command.City,
                command.Address,
                command.TypeOfInsuranceSend, command.TypeOfContract,command.ContractTerm);
            _workshopRepository.Create(workshop);
            _workshopRepository.SaveChanges();

           

                foreach (var e in employer)
                {
                    _workshopRepository.EmployerWorkshop(workshop.id, e);
                }

                
                _workshopRepository.WorkshopAccounts(accountIds, workshop.id);



            return operation.Succcedded();

        }

        public OperationResult Edit(EditWorkshop command)
        {
            var accountIds = new List<long>();
            var operation = new OperationResult();
            var workshop = _workshopRepository.Get(command.Id);
            if (command.AccountIdsList != null)
            {
                accountIds = command.AccountIdsList.ToList();
            }
            if (workshop == null)
                operation.Failed("رکورد مورد نظر وجود ندارد");
            if (command.EmployerIdList == null)
                return operation.Failed("لطفا کارفرما را انتخاب نمایید");
            var employer = command.EmployerIdList.ToList();
            if (_workshopRepository.Exists(x => x.WorkshopName == command.WorkshopName && x.id != command.Id))
                return operation.Failed(" رکورد مورد نظر تکراری است ");
            if (_workshopRepository.Exists(x => x.InsuranceCode != null && x.InsuranceCode == command.InsuranceCode && x.id != command.Id))
                return operation.Failed("کد بیمه کارگاه تکراری است");
            if (command.Address != null && command.State == null)
                return operation.Failed("لطفا استان و شهر را انتخاب کنید");
            if ((command.Address != null && command.State != null) && command.City == "لطفا شهر را انتخاب نمایید")
                return operation.Failed("لطفا شهر را انتخاب کنید");
            if (command.TypeOfInsuranceSend != null && command.InsuranceCode == null)
                return operation.Failed("لطفا کد بیمه کارگاه را وارد کنید");
            if (command.Address == null && command.State != null) 
                return operation.Failed("لطفا آدرس را وارد کنید");
            

            workshop.Edit(command.WorkshopName, command.WorkshopSureName, command.InsuranceCode,  command.TypeOfOwnership,
                command.ArchiveCode, command.AgentName, command.AgentPhone, command.State, command.City,
                command.Address,
                command.TypeOfInsuranceSend, command.TypeOfContract,command.ContractTerm);
            _workshopRepository.SaveChanges();

            _workshopRepository.RemoveOldRelation(command.Id);
            foreach (var e in employer)
            {
                _workshopRepository.EmployerWorkshop(workshop.id, e);
            }
            _workshopRepository.WorkshopAccounts(accountIds, workshop.id);
            return operation.Succcedded();

        }

        public EditWorkshop GetDetails(long id)
        {
            return _workshopRepository.GetDetails(id);
        }

        public List<WorkshopViewModel> GetWorkshop()
        {
            return _workshopRepository.GetWorkshop();
        }

        public List<WorkshopViewModel> GetWorkshopAccount()
        {
            return _workshopRepository.GetWorkshopAccount();
        }

        public List<WorkshopViewModel> Search(WorkshopSearchModel searchModel)
        {
            return _workshopRepository.Search(searchModel);
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var workshop = _workshopRepository.Get(id);
            if (workshop == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            workshop.Active(workshop.ArchiveCode);

            _workshopRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var workshop = _workshopRepository.Get(id);
            if (workshop == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            workshop.DeActive(workshop.ArchiveCode);
            var s = workshop.ArchiveCode;
            
            _workshopRepository.SaveChanges();
            return opration.Succcedded();
        }

        public WorkshopViewModel GetWorkshopInfo(long id)
        {
            return _workshopRepository.GetWorkshopInfo(id);
        }


        public OperationResult Err()
        {
            var opration = new OperationResult();
            return opration.Failed("شماره بایگانی باید شامل عدد باشد");
        }

        public OperationResult ExistErr()
        {
            var opration = new OperationResult();
            return opration.Failed("شماره بایگانی تکراری است");
        }


    }
}
