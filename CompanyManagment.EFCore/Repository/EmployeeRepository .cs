using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Company.Domain.EmployeeAgg;
using CompanyManagment.App.Contracts.Employee;

namespace CompanyManagment.EFCore.Repository
{
    public class EmployeeRepository : RepositoryBase<long, Employee>, IEmployeeRepository
    {
        private readonly CompanyContext _context;
        public bool nationalCodValid = false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool StatCity = true;
        public bool city = true;
        public DateTime initial = new DateTime(1922, 01, 01, 00, 00, 00, 0000000);
        public EmployeeRepository(CompanyContext context) :base(context)
        {
            _context = context;
        }

        public List<EmployeeViewModel> GetEmployee()
        {
            return _context.Employees.Where(x=>x.IsActive).Select(x => new EmployeeViewModel
            {
                Id = x.id,
                FName = x.FName,
                
                LName = x.LName,
                EmployeeFullName = x.FName +" "+x.LName,
                FatherName = x.FatherName,
                NationalCode = x.NationalCode,
                IdNumber = x.IdNumber,
                DateOfBirth = x.DateOfBirth == initial ? "" : x.DateOfBirth.ToFarsi(),
                Address = x.Address,
                State = x.State,
                City = x.City
            }).ToList();
        }
        public EditEmployee GetDetails(long id)
        {
            return _context.Employees.Select(x => new EditEmployee
                {
                  Id = x.id,
                  FName = x.FName,
                  LName = x.LName,
                  Gender = x.Gender,
                  NationalCode = x.NationalCode,
                  IdNumber = x.IdNumber,
                  Nationality = x.Nationality,
                  FatherName = x.FatherName,
                  DateOfBirth = x.DateOfBirth == initial ? "" : x.DateOfBirth.ToFarsi(),
                  DateOfIssue = x.DateOfIssue == initial ? "" : x.DateOfIssue.ToFarsi(),
                  PlaceOfIssue = x.PlaceOfIssue,
                  Phone = x.Phone,
                  Address = x.Address,
                  State = x.State,
                  City = x.City,
                  MaritalStatus = x.MaritalStatus,
                  MilitaryService = x.MilitaryService,
                  LevelOfEducation = x.LevelOfEducation,
                  FieldOfStudy = x.FieldOfStudy,
                  BankCardNumber = x.BankCardNumber,
                  BankBranch = x.BankBranch,
                  InsuranceCode = x.InsuranceCode,
                  InsuranceHistoryByYear = x.InsuranceHistoryByYear,
                  InsuranceHistoryByMonth = x.InsuranceHistoryByMonth,
                  NumberOfChildren = x.NumberOfChildren,
                  OfficePhone = x.OfficePhone,
                  EmployeeFullName = x.FName + " " + x.LName,
                  MclsUserName =x.MclsUserName,
                  MclsPassword = x.MclsPassword,
                  EserviceUserName = x.EserviceUserName,
                  EservicePassword = x.EservicePassword,
                  TaxOfficeUserName = x.TaxOfficeUserName,
                  TaxOfficepassword = x.TaxOfficepassword,
                  SanaUserName = x.SanaUserName,
                  SanaPassword = x.SanaPassword,



            })
                .FirstOrDefault(x => x.Id == id);
            
        }

        public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel)
        {
            var query = _context.Employees.Select(x => new EmployeeViewModel
                {
                    Id = x.id,
                    FName = x.FName,
                   
                    LName = x.LName,
                    NationalCode = x.NationalCode,
                    IdNumber = x.IdNumber,
                     EmployeeFullName = x.FName + " " + x.LName,
                    IsActiveString = x.IsActiveString,
                  

                });

            if (!string.IsNullOrWhiteSpace(searchModel.FName))
                query = query.Where(x => x.FName.Contains(searchModel.FName));
            if (!string.IsNullOrWhiteSpace(searchModel.LName))
                query = query.Where(x => x.LName.Contains(searchModel.LName));
            if (!string.IsNullOrWhiteSpace(searchModel.NationalCode))
                query = query.Where(x => x.NationalCode.Contains(searchModel.NationalCode));
            if (!string.IsNullOrWhiteSpace(searchModel.IdNumber))
                query = query.Where(x => x.IdNumber.Contains(searchModel.IdNumber));

            if (searchModel.IsActiveString == null)
            {
                query = query.Where(x => x.IsActiveString == "true");
            }

            if (searchModel.IsActiveString == "false")
            {
                query = query.Where(x => x.IsActiveString == "false");
            }
            else if (searchModel.IsActiveString == "both")
            {
                query = query.Where(x => x.IsActiveString == "false" || x.IsActiveString == "true");
            }








            return query.OrderByDescending(x => x.Id).ToList();
        }

      

    }
}
