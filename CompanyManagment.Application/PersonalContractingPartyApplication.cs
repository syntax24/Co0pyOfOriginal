using System;
using System.Collections.Generic;
using _0_Framework.Application;
using CompanyManagment.App.Contracts.PersonalContractingParty;
using Company.Domain.ContarctingPartyAgg;

namespace CompanyManagment.Application
{
    public class PersonalContractingPartyApplication : IPersonalContractingPartyApp
    {
        private readonly IPersonalContractingPartyRepository _personalContractingPartyRepository2;
        public bool nationalCodValid=false;
        public bool idnumberIsOk = true;
        public bool nameIsOk = true;
        public bool nationalcodeIsOk = true;
        public bool legalNameIsOk = true;

        public bool registerIdIsOk = true;
        public bool nationalIdIsOk = true;
        public PersonalContractingPartyApplication(
            IPersonalContractingPartyRepository personalContractingPartyRepository)
        {
            _personalContractingPartyRepository2 = personalContractingPartyRepository;
        }

        public OperationResult Create(CreatePersonalContractingParty command)
        {
            var opration = new OperationResult();
            if (_personalContractingPartyRepository2.Exists(x =>
                x.LName == command.LName && x.Nationalcode == command.Nationalcode))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            if (_personalContractingPartyRepository2.Exists(x => x.IdNumber == command.IdNumber))
            {
                idnumberIsOk = false;

                return opration.Failed("شماره شناسنامه وارد شده تکراری است");
            }
            if (_personalContractingPartyRepository2.Exists(x =>  x.LName == command.LName))
            {
                nameIsOk = false;
            
                return opration.Failed("نام خانوادگی وارد شده تکراری است");

            }
            if (_personalContractingPartyRepository2.Exists(x => x.Nationalcode == command.Nationalcode))
            {
                nationalcodeIsOk = false;
               
                return opration.Failed("کد ملی وارد شده تکراری است");
            }


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

            if (idnumberIsOk && nationalCodValid && nameIsOk && nationalcodeIsOk)
            {
                var personalContractingParty = new PersonalContractingParty(command.FName, command.LName,
                    command.Nationalcode, command.IdNumber, "*", "*", 
                    "حقیقی",
                    command.Phone, command.AgentPhone, command.Address);


                _personalContractingPartyRepository2.Create(personalContractingParty);
                _personalContractingPartyRepository2.SaveChanges();

                return opration.Succcedded();

            }
            else
            {
                return opration.Failed("خطایی رخ داده است");
            }



           

        }

        public OperationResult Edit2(EditPersonalContractingParty command)
        {
            var opration = new OperationResult();
            var personalContractingParty = _personalContractingPartyRepository2.Get(command.Id);
            if (personalContractingParty == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            personalContractingParty.Edit2(command.Address);

            _personalContractingPartyRepository2.SaveChanges();
            return opration.Succcedded();
        }

        public OperationResult CreateLegals(CreatePersonalContractingParty command)
        {
           
            var opration = new OperationResult();
            if (_personalContractingPartyRepository2.Exists(x =>
                x.LName == command.LName && x.RegisterId == command.RegisterId))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
           



            if (_personalContractingPartyRepository2.Exists(x => x.LName == command.LName))
            {
                legalNameIsOk = false;
                return opration.Failed("نام شرکت  وارد شده تکراری است");
            }
            if (_personalContractingPartyRepository2.Exists(x => x.RegisterId == command.RegisterId))
            {
                registerIdIsOk = false;
                return opration.Failed("شماره ثبت وارد شده تکراری است");

            }
            if (_personalContractingPartyRepository2.Exists(x => x.NationalId == command.NationalId))
            {
                nationalIdIsOk = false;
                return opration.Failed("شناسه ملی وارد شده تکراری است");
            }



            if (legalNameIsOk && registerIdIsOk && nationalIdIsOk)
            {
                var legalContractingParty = new PersonalContractingParty("*", command.LName,
                    "*", "*",  command.RegisterId, command.NationalId,
                    "حقوقی",
                    command.Phone, command.AgentPhone, command.Address);


                _personalContractingPartyRepository2.Create(legalContractingParty);
                _personalContractingPartyRepository2.SaveChanges();

                return opration.Succcedded();

            }
            else
            {
                return opration.Failed("خطایی رخ داده است");
            }


           
        }

        public OperationResult Edit(EditPersonalContractingParty command)
        {
            
            var opration = new OperationResult();
            var personalContractingParty = _personalContractingPartyRepository2.Get(command.Id);
            if (personalContractingParty == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_personalContractingPartyRepository2.Exists(x =>
                x.LName == command.LName && x.Nationalcode == command.Nationalcode && x.id != command.Id))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");
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

            if (nationalCodValid)
            {
                personalContractingParty.Edit(command.FName, command.LName,
                    command.Nationalcode, command.IdNumber, 
                    command.Phone, command.AgentPhone, command.Address);

                _personalContractingPartyRepository2.SaveChanges();
                return opration.Succcedded();
            }
            else
            {
                return opration.Failed("خطایی رخ داده است");
            }
      
        }

        public OperationResult EditLegal(EditPersonalContractingParty command)
        {
            
            var opration = new OperationResult();
            var legalContractingParty = _personalContractingPartyRepository2.Get(command.Id);
            if (legalContractingParty == null)
                return opration.Failed("رکورد مورد نظر یافت نشد");

            if (_personalContractingPartyRepository2.Exists(x =>
                x.LName== command.LName && x.RegisterId == command.RegisterId && x.id != command.Id))
                return opration.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            legalContractingParty.EditLegal(command.LName, command.RegisterId,
                command.NationalId,
                command.Phone, command.AgentPhone, command.Address);

            _personalContractingPartyRepository2.SaveChanges();
            return opration.Succcedded();
        }

        public EditPersonalContractingParty GetDetails(long id)
        {
            return _personalContractingPartyRepository2.GetDetails(id);
        }

        public List<PersonalContractingPartyViewModel> GetPersonalContractingParties()
        {
            return _personalContractingPartyRepository2.GetPersonalContractingParties();
        }

        public List<PersonalContractingPartyViewModel> Search(PersonalContractingPartySearchModel searchModel2)
        {
            return _personalContractingPartyRepository2.Search(searchModel2);
        }

      
    }
}
