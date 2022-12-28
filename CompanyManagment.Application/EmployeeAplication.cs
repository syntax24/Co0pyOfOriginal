using System;
using System.Collections.Generic;

using _0_Framework.InfraStructure;
using Company.Domain.EmployeeAgg;
using CompanyManagment.App.Contracts.Employee;
using CompanyManagment.EFCore;
using _0_Framework.Application;

namespace CompanyManagment.Application
{
    public class EmployeeAplication : RepositoryBase<long, Employee>, IEmployeeApplication
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly CompanyContext _context;
        public bool nationalCodValid = false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool StatCity = true;
        public bool city = true;
        public bool address = true;

        public EmployeeAplication(IEmployeeRepository employeeRepository, CompanyContext context) : base(context)
        {
            _context = context;
            _EmployeeRepository = employeeRepository;
        }

        public OperationResult Create(CreateEmployee command)
        {
            var opration = new OperationResult();
            if (_EmployeeRepository.Exists(x =>
                x.LName == command.LName && x.NationalCode == command.NationalCode && x.NationalCode != null))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            //if (_EmployeeRepository.Exists(x => x.IdNumber == command.IdNumber && x.IdNumber !=null))
            //{
            //    idnumberIsOk = false;

            //    return opration.Failed("شماره شناسنامه وارد شده تکراری است");
            //}

            if (_EmployeeRepository.Exists(x => x.LName == command.LName && x.FName == command.FName))
            {
                nameIsOk = false;

                return opration.Failed("نام و نام خانوادگی وارد شده تکراری است");

            }

       

            if (command.Address != null && command.State == null)
            {
                StatCity = false;
                return opration.Failed("لطفا استان و شهر را انتخاب کنید");
            }

            if ((command.Address != null && command.State != null) && command.City == "لطفا شهر را انتخاب نمایید")
            {
                city = false;
                return opration.Failed("لطفا شهر را انتخاب کنید");
            }

            if (command.Address == null && command.State != null)
            {
                address = false;
                return opration.Failed("لطفا آدرس را وارد کنید");
            }

            if (!string.IsNullOrWhiteSpace(command.NationalCode))
            {
                try
                {


                    char[] chArray = command.NationalCode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }

                    int num2 = numArray[9];
                    switch (command.NationalCode)
                    {
                        case "0000000000":
                        case "1111111111":
                        case "22222222222":
                        case "33333333333":
                        case "4444444444":
                        case "5555555555":
                        case "6666666666":
                        case "7777777777":
                        case "8888888888":
                        case "9999999999":



                            nationalCodValid = false;
                            return opration.Failed("کد ملی وارد شده صحیح نمی باشد");


                    }

                    int num3 =
                        ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) +
                            (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) +
                        (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) ||
                        ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
                    {



                        nationalCodValid = true;


                    }
                    else
                    {

                        nationalCodValid = false;
                        return opration.Failed("کد ملی وارد شده نا معتبر است");
                    }
                }
                catch (Exception)
                {

                    nationalCodValid = false;
                    return opration.Failed("لطفا کد ملی 10 رقمی وارد کنید");

                }
                if (_EmployeeRepository.Exists(x => x.NationalCode == command.NationalCode))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("کد ملی وارد شده تکراری است");
                }
            }
                

           
                string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();

               
                var employeeData = new Employee(command.FName, command.LName, command.FatherName, dateOfBirth,
                    dateOfIssue,
                    command.PlaceOfIssue, command.NationalCode, command.IdNumber, command.Gender, command.Nationality,
                    command.Phone, command.Address,
                    command.State, command.City, command.MaritalStatus, command.MilitaryService, command.LevelOfEducation,
                    command.FieldOfStudy, command.BankCardNumber,
                    command.BankBranch, command.InsuranceCode, command.InsuranceHistoryByYear,
                    command.InsuranceHistoryByMonth, command.NumberOfChildren, command.OfficePhone, command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword);


                _EmployeeRepository.Create(employeeData);
                _EmployeeRepository.SaveChanges();

                return opration.Succcedded();

          
        }

        public OperationResult Edit(EditEmployee command)
        {
            var opration = new OperationResult();
            var employee = _EmployeeRepository.Get(command.Id);
            if (employee == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_EmployeeRepository.Exists(x =>
                x.LName == command.LName && x.NationalCode == command.NationalCode && x.id != command.Id))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            //if (_EmployeeRepository.Exists(x => x.IdNumber == command.IdNumber && x.IdNumber != null && x.id != command.Id))
            //    return opration.Failed("شماره شناسنامه وارد شده تکراری است");
           
            if (command.Address != null && command.State == null)
            {
                StatCity = false;
                return opration.Failed("لطفا استان و شهر را انتخاب کنید");
            }

            if ((command.Address != null && command.State != null) && command.City == "لطفا شهر را انتخاب نمایید")
            {
                city = false;
                return opration.Failed("لطفا شهر را انتخاب کنید");
            }

            if (command.Address == null && command.State != null)
            {
                address = false;
                return opration.Failed("لطفا آدرس را وارد کنید");
            }

            if (!string.IsNullOrWhiteSpace(command.NationalCode))
            {
                try
                {


                    char[] chArray = command.NationalCode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }

                    int num2 = numArray[9];
                    switch (command.NationalCode)
                    {
                        case "0000000000":
                        case "1111111111":
                        case "22222222222":
                        case "33333333333":
                        case "4444444444":
                        case "5555555555":
                        case "6666666666":
                        case "7777777777":
                        case "8888888888":
                        case "9999999999":



                            nationalCodValid = false;
                            return opration.Failed("کد ملی وارد شده صحیح نمی باشد");


                    }

                    int num3 =
                        ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) +
                            (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) +
                        (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) ||
                        ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
                    {



                        nationalCodValid = true;


                    }
                    else
                    {

                        nationalCodValid = false;
                        return opration.Failed("کد ملی وارد شده نا معتبر است");
                    }
                }
                catch (Exception)
                {

                    nationalCodValid = false;
                    return opration.Failed("لطفا کد ملی 10 رقمی وارد کنید");

                }
                if (_EmployeeRepository.Exists(x => x.NationalCode == command.NationalCode))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("کد ملی وارد شده تکراری است");
                }
            }

            
                string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                employee.Edit(command.FName, command.LName, command.FatherName, dateOfBirth,
                    dateOfIssue,
                    command.PlaceOfIssue, command.NationalCode, command.IdNumber, command.Gender, command.Nationality,
                    command.Phone, command.Address,
                    command.State,command.City, command.MaritalStatus, command.MilitaryService, command.LevelOfEducation,
                    command.FieldOfStudy, command.BankCardNumber,
                    command.BankBranch, command.InsuranceCode, command.InsuranceHistoryByYear,
                    command.InsuranceHistoryByMonth, command.NumberOfChildren, command.OfficePhone
                    , command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword);



                _EmployeeRepository.SaveChanges();

                return opration.Succcedded();

         
        }

        public EditEmployee GetDetails(long id)
        {
            return _EmployeeRepository.GetDetails(id);
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var employer = _EmployeeRepository.Get(id);
            if (employer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            employer.Active();

            _EmployeeRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var employer = _EmployeeRepository.Get(id);
            if (employer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            employer.DeActive();

            _EmployeeRepository.SaveChanges();
            return opration.Succcedded();
        }

        public List<EmployeeViewModel> GetEmployee()
        {
            return _EmployeeRepository.GetEmployee();
        }

        public List<EmployeeViewModel> Search(EmployeeSearchModel searchModel)
        {
            return _EmployeeRepository.Search(searchModel);
        }
    }
}
