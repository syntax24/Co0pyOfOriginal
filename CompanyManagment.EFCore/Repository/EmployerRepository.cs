using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.empolyerAgg;
using CompanyManagment.App.Contracts.Employer;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagment.EFCore.Repository
{
    public class EmployerRepository : RepositoryBase<long, Employer>, IEmployerRepository
    {
        private readonly CompanyContext _context;
        public DateTime initial = new DateTime(1922, 01, 01, 00, 00, 00, 0000000);
       
        public EmployerRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }

        public List<EmployerViewModel> GetEmployers()
        {
            return _context.Employers.Where(x=>x.IsActive==true).Select(x => new EmployerViewModel
            {
                Id = x.id,

                FName = x.FName,
                LName = x.LName,
                FullName = x.FullName,
                Nationalcode = x.Nationalcode,
                IdNumber = x.IdNumber,
                RegisterId = x.RegisterId,
                NationalId = x.NationalId,
                IsLegal = x.IsLegal,
                Phone = x.Phone,
                AgentPhone = x.AgentPhone,
                Address = x.Address

            }).ToList();
        }

        public List<EmployerViewModel> GetEmployers(List<long> id)
        {

            var empList = new List<EmployerViewModel>();
            foreach (var item in id)
            {
                var e = _context.Employers.Where(x=>x.IsActive).Select(x => new EmployerViewModel
                {
                    Id = x.id,

                    FName = x.FName,
                    LName = x.LName,
                    FullName = x.FullName,
                    Nationalcode = x.Nationalcode,
                    IdNumber = x.IdNumber,
                    RegisterId = x.RegisterId,
                    NationalId = x.NationalId,
                    IsLegal = x.IsLegal,
                    Phone = x.Phone,
                    AgentPhone = x.AgentPhone,
                    Address = x.Address

                })
                    .SingleOrDefault(x=>x.Id == item);
                empList.Add(e);
            }

            return empList;

        }

        public EditEmployer GetDetails(long id)
        {
            return _context.Employers.Select(x => new EditEmployer
            {
                Id = x.id,
                FName = x.FName,
                LName = x.LName,
                ContractingPartyId = x.ContractingPartyId,
                Gender = x.Gender,
                Nationalcode = x.Nationalcode,
                IdNumber = x.IdNumber,
                Nationality = x.Nationality,
                FatherName = x.FatherName,
                DateOfBirth = x.DateOfBirth == initial ? "" : x.DateOfBirth.ToFarsi(),
                DateOfIssue = x.DateOfIssue == initial ? "" : x.DateOfIssue.ToFarsi(),
                PlaceOfIssue = x.PlaceOfIssue,
                RegisterId = x.RegisterId,
                NationalId = x.NationalId,
                EmployerLName = x.EmployerLName,
                IsLegal = x.IsLegal,
                Phone = x.Phone,
                AgentPhone = x.AgentPhone,
                Address = x.Address,
                MclsUserName = x.MclsUserName,
                MclsPassword = x.MclsPassword,
                EserviceUserName = x.EserviceUserName,
                EservicePassword = x.EservicePassword,
                TaxOfficeUserName = x.EservicePassword,
                SanaUserName = x.SanaUserName,
                SanaPassword = x.SanaPassword,
                EmployerNo = x.EmployerNo,
                FullName = x.FullName



            })
                .FirstOrDefault(x => x.Id == id);
        }

        public List<EmployerViewModel> Search(EmployerSearchModel searchModel)
        {
            var query = _context.Employers.Include(x => x.ContractingParty)
                .Select(x => new EmployerViewModel
                {
                    Id = x.id,
                    FName = x.FName,
                    ContractingPartyID = x.ContractingPartyId,
                    LName = x.LName,
                    Nationalcode = x.Nationalcode,
                    IdNumber = x.IdNumber,
                    EmployerLName = x.EmployerLName,
                    IsLegal = x.IsLegal,
                    RegisterId = x.RegisterId,
                    NationalId = x.NationalId,
                    ContractingParty = x.ContractingParty.LName,
                    IsActive = x.IsActive,
                    Address = x.Address,
                    EmployerNo = x.EmployerNo,

                });

            if (!string.IsNullOrWhiteSpace(searchModel.FName))
                query = query.Where(x => x.FName.Contains(searchModel.FName));
            if (!string.IsNullOrWhiteSpace(searchModel.LName))
                query = query.Where(x => x.LName.Contains(searchModel.LName));
            if (!string.IsNullOrWhiteSpace(searchModel.Nationalcode))
                query = query.Where(x => x.Nationalcode.Contains(searchModel.Nationalcode));
            if (!string.IsNullOrWhiteSpace(searchModel.IdNumber))
                query = query.Where(x => x.IdNumber.Contains(searchModel.IdNumber));
            if (!string.IsNullOrWhiteSpace(searchModel.RegisterId))
                query = query.Where(x => x.RegisterId.Contains(searchModel.RegisterId));
            if (!string.IsNullOrWhiteSpace(searchModel.NationalId))
                query = query.Where(x => x.NationalId.Contains(searchModel.NationalId));
            if (!string.IsNullOrWhiteSpace(searchModel.EmployerLName))
                query = query.Where(x => x.EmployerLName.Contains(searchModel.EmployerLName));
            if (!string.IsNullOrWhiteSpace(searchModel.IsLegal))
                query = query.Where(x => x.IsLegal.Contains(searchModel.IsLegal));
            if (searchModel.ContractingPartyID != 0)
                query = query.Where(x => x.ContractingPartyID == searchModel.ContractingPartyID);
            if (searchModel.Address == null)
            {
                query = query.Where(x => x.Address == "true");
            }

            if (searchModel.Address == "false")
            {
                query = query.Where(x => x.Address == "false");
            }
            else if (searchModel.Address == "both")
            {
                query = query.Where(x => x.Address == "false" || x.Address == "true");
            }




            //if (searchModel.IsActive==false)
            //{
            //    query = query.Where(x => x.IsActive == true);
            //}
            //else if(searchModel.IsActive)
            //{
            //    query = query.Where(x => x.IsActive == false || x.IsActive == true);
            //}

            //else
            //{

            //}



            //if (!searchModel.IsActive)
            //    query = query.Where(x => !x.IsActive);
            //query = query.Where(x => x.IsActive == searchModel.IsActive);




            return query.OrderByDescending(x => x.Id).ToList();
        }


    }
}
