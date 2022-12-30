using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.empolyerAgg;
using CompanyManagment.App.Contracts.Employer;

namespace CompanyManagment.Application
{
    public class EmployerApplication : IEmployerApplication
    {
        private readonly IEmployerRepository _EmployerRepository;
        public bool nationalCodValid = false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool legalNameIsOk = true;

        public bool registerIdIsOk = true;
        public bool nationalIdIsOk = true;
        public EmployerApplication(IEmployerRepository employerRepository)
        {
            _EmployerRepository = employerRepository;
        }

        public OperationResult Active(long id)
        {
            var opration = new OperationResult();
            var employer = _EmployerRepository.Get(id);
            if (employer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            employer.Active();

            _EmployerRepository.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult Create(CreateEmployer command)
        {
            var opration = new OperationResult();
            if (_EmployerRepository.Exists(x =>
                x.LName == command.LName && x.Nationalcode == command.Nationalcode && x.Nationalcode != null))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            //if (_EmployerRepository.Exists(x => x.IdNumber == command.IdNumber && x.IdNumber != null))
            //    return opration.Failed("شماره شناسنامه وارد شده تکراری است");
            if (_EmployerRepository.Exists(x => x.LName == command.LName && x.FName == command.FName))
            {
                nameIsOk = false;

                return opration.Failed("نام و نام خانوادگی وارد شده تکراری است");

            }

            if (string.IsNullOrWhiteSpace(command.FName))
                return opration.Failed("لطفا نام را وارد کنید");
            if (!string.IsNullOrWhiteSpace(command.Nationalcode))
            {
                try
                {


                    char[] chArray = command.Nationalcode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }
                    int num2 = numArray[9];
                    switch (command.Nationalcode)
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
                    int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
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

                if (_EmployerRepository.Exists(x => x.Nationalcode == command.Nationalcode))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("کد ملی وارد شده تکراری است");
                }
            }
          
            
                string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var employerData = new Employer(command.FName, command.LName, command.ContractingPartyId,command.Gender,
                    command.Nationalcode, command.IdNumber, command.Nationality, command.FatherName, dateOfBirth,
                    dateOfIssue, command.PlaceOfIssue, "*","*","*","حقیقی", command.Phone,
                    command.AgentPhone, "true", command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword);


                _EmployerRepository.Create(employerData);
                _EmployerRepository.SaveChanges();

                return opration.Succcedded();

          
        }

        public OperationResult CreateLegals(CreateEmployer command)
        {
            if (string.IsNullOrWhiteSpace(command.EmployerLName))
                command.EmployerLName = "#";
            var opration = new OperationResult();
            if (_EmployerRepository.Exists(x =>
                x.LName == command.LName && x.NationalId == command.NationalId && x.EmployerLName == command.EmployerLName))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            if (_EmployerRepository.Exists(x => x.NationalId == command.NationalId && x.NationalId != null))
            {
                nationalIdIsOk = false;

                return opration.Failed(" شناسه ملی وارد شده تکراری است");
            }
            if (_EmployerRepository.Exists(x => x.LName == command.LName))
            {
                nameIsOk = false;

                return opration.Failed("نام شرکت وارد شده تکراری است");

            }
            if (_EmployerRepository.Exists(x => x.RegisterId == command.RegisterId && x.RegisterId !=null))
            {
                registerIdIsOk = false;

                return opration.Failed(" شماره ثبت وارد شده تکراری است");
            }
            if (_EmployerRepository.Exists(x => x.EmployerLName == command.EmployerLName && x.EmployerLName !="#"))
            {
                legalNameIsOk = false;

                return opration.Failed("  نام کارفرمای وارد شده تکراری است");
            }

           

            //if (_EmployerRepository.Exists(x => x.IdNumber == command.IdNumber && x.IdNumber != null))
            //{
            //    idnumberIsOk = false;

            //    return opration.Failed("شمار شناسنامه  وارد شده تکراری است");
            //}
            if (!string.IsNullOrWhiteSpace(command.Nationalcode))
            {
                try
                {


                    char[] chArray = command.Nationalcode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }
                    int num2 = numArray[9];
                    switch (command.Nationalcode)
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
                    int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
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
                if (_EmployerRepository.Exists(x => x.Nationalcode == command.Nationalcode))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("  کد ملی  وارد شده تکراری است");
                }
            }
          

                string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var LegalEmployerData = new Employer(command.FName, command.LName, command.ContractingPartyId, command.Gender,
                    command.Nationalcode, command.IdNumber, command.Nationality, command.FatherName, dateOfBirth,
                    dateOfIssue, command.PlaceOfIssue, command.RegisterId, command.NationalId, command.EmployerLName, "حقوقی", command.Phone,
                    command.AgentPhone, "true", command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword);


                _EmployerRepository.Create(LegalEmployerData);
                _EmployerRepository.SaveChanges();

                return opration.Succcedded();

         
        }

        public OperationResult DeActive(long id)
        {
            var opration = new OperationResult();
            var employer = _EmployerRepository.Get(id);
            if (employer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            employer.DeActive();

            _EmployerRepository.SaveChanges();
            return opration.Succcedded();
        }

        public List<EmployerViewModel> GetEmployers()
        {
            return _EmployerRepository.GetEmployers();
        }

        public OperationResult Edit(EditEmployer command)
        {
            var opration = new OperationResult();
            var employer = _EmployerRepository.Get(command.Id);
            if (employer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_EmployerRepository.Exists(x =>
                x.LName == command.LName && x.Nationalcode == command.Nationalcode && x.id != command.Id))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            if (!string.IsNullOrWhiteSpace(command.Nationalcode))
            {
                try
                {


                    char[] chArray = command.Nationalcode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }
                    int num2 = numArray[9];
                    switch (command.Nationalcode)
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
                    int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
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
                if (_EmployerRepository.Exists(x => x.Nationalcode == command.Nationalcode && x.id != command.Id))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("  کد ملی  وارد شده تکراری است");
                }
            }

           
                string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                employer.Edit(command.FName, command.LName, command.ContractingPartyId,
                    command.Gender, command.Nationalcode, command.IdNumber, command.Nationality, command.FatherName,
                    dateOfBirth, dateOfIssue, command.PlaceOfIssue, command.Phone, command.AgentPhone,
                     command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword, command.EmployerNo);

                _EmployerRepository.SaveChanges();
                return opration.Succcedded();
            
          
        }

        public OperationResult EditEmployerNo(EditEmployer command)
        {
            var opration = new OperationResult();
            var EmployerNumber = _EmployerRepository.Get(command.Id);
            if (EmployerNumber == null)
                return opration.Failed("کارفرمای مورد نظر جهت تخصخی شماره یافت نشد");

            if (string.IsNullOrWhiteSpace(EmployerNumber.EmployerNo))
            {
                EmployerNumber.EditEmployerNo(command.EmployerNo);
                _EmployerRepository.SaveChanges();
                return opration.Succcedded();
            }
            else
            {
                return null;
            }
            
        }

        public OperationResult EditLegal(EditEmployer command)
        {
            var opration = new OperationResult();
            var legalEmployer = _EmployerRepository.Get(command.Id);
            if (legalEmployer == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_EmployerRepository.Exists(x =>
                x.LName == command.LName && x.NationalId == command.NationalId  && x.id != command.Id))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            if (!string.IsNullOrWhiteSpace(command.Nationalcode))
            {
                try
                {


                    char[] chArray = command.Nationalcode.ToCharArray();
                    int[] numArray = new int[chArray.Length];
                    var cunt = chArray.Length;
                    for (int i = 0; i < chArray.Length; i++)
                    {
                        numArray[i] = (int)char.GetNumericValue(chArray[i]);
                    }
                    int num2 = numArray[9];
                    switch (command.Nationalcode)
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
                    int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
                    int num4 = num3 - ((num3 / 11) * 11);
                    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
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
                if (_EmployerRepository.Exists(x => x.Nationalcode == command.Nationalcode && x.id != command.Id))
                {
                    nationalcodeIsOk = false;

                    return opration.Failed("  کد ملی  وارد شده تکراری است");
                }
            }
            string initial = "1300/10/11";
                var dateOfBirth = command.DateOfBirth != null ? command.DateOfBirth.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                var dateOfIssue = command.DateOfIssue != null ? command.DateOfIssue.ToGeorgianDateTime() : initial.ToGeorgianDateTime();
                legalEmployer.EditLegal(command.FName, command.LName, command.ContractingPartyId, command.Gender,
                    command.Nationalcode, command.IdNumber, command.Nationality, command.FatherName, dateOfBirth,
                    dateOfIssue, command.PlaceOfIssue, command.RegisterId, command.NationalId, command.EmployerLName,
                    command.Phone, command.AgentPhone, command.MclsUserName, command.MclsPassword, command.EserviceUserName, command.EservicePassword,
                    command.TaxOfficeUserName, command.TaxOfficepassword, command.SanaUserName, command.SanaPassword, command.EmployerNo);

                _EmployerRepository.SaveChanges();
                return opration.Succcedded();
         
        }

        public EditEmployer GetDetails(long id)
        {
            return _EmployerRepository.GetDetails(id);
        }

        public List<EmployerViewModel> Search(EmployerSearchModel searchModel)
        {
            return _EmployerRepository.Search(searchModel);
        }
    }
}
