using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _0_Framework.Application;
using Company.Domain.ContarctingPartyAgg;

using CompanyManagment.App.Contracts.PersonalContractingParty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Company.ContractingParties
{
    [Authorize]
    public class IndexModel : PageModel
    {
     

        public PersonalContractingPartySearchModel SearchModel2;
        public List<PersonalContractingPartyViewModel> personals;
        public List<CreatePersonalContractingParty> personCreat;
        private readonly IPersonalContractingPartyApp _PersonalContractingPartyApp;

        private readonly IPersonalContractingPartyRepository _PersonalContractingPartyRepository;


        public IndexModel(IPersonalContractingPartyApp personalContractingPartyApp, IPersonalContractingPartyRepository personalContractingPartyRepository)
        {
            _PersonalContractingPartyApp = personalContractingPartyApp;
            _PersonalContractingPartyRepository = personalContractingPartyRepository;
         
        }

        public void OnGet(PersonalContractingPartySearchModel searchModel2)
        {
            personals = _PersonalContractingPartyApp.Search(searchModel2);

            

        }

    

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreatePersonalContractingParty());
        }

        public IActionResult OnGetInsertLegal()
        {
            return Partial("./InsertLegal", new CreatePersonalContractingParty());
        }
        public IActionResult OnPostCreate(CreatePersonalContractingParty command)
        {

            var result = _PersonalContractingPartyApp.Create(command);
            return new JsonResult(result);

            //bool idnumberIsOk = true;
            //bool nationalCodValid = true;
            //bool nameIsOk = true;
            //bool nationalcodeIsOk = true;



            //if (_PersonalContractingPartyRepository.Exists(x => x.IdNumber == command.IdNumber))
            //{
            //    idnumberIsOk = false;
            //    TempData["IdR"] = "شماره شناسنامه وارد شده تکراری است";
            //}
            //if (_PersonalContractingPartyRepository.Exists(x => x.FName == command.FName && x.LName == command.LName))
            //{
            //    nameIsOk = false;
            //    TempData["name"] = "نام وارد شده تکراری است";
            //    TempData["family"] = "نام خانوادگی وارد شده تکراری است";
            //}
            //if (_PersonalContractingPartyRepository.Exists(x => x.Nationalcode == command.Nationalcode))
            //{
            //    nationalcodeIsOk = false;
            //    TempData["NationalCode"] = "کد ملی وارد شده تکراری است";
            //}

            //try
            //{


            //    char[] chArray = command.Nationalcode.ToCharArray();
            //    int[] numArray = new int[chArray.Length];
            //    var cunt = chArray.Length;
            //    for (int i = 0; i < chArray.Length; i++)
            //    {
            //        numArray[i] = (int)char.GetNumericValue(chArray[i]);
            //    }
            //    int num2 = numArray[9];
            //    switch (command.Nationalcode)
            //    {
            //        case "0000000000":
            //        case "1111111111":
            //        case "22222222222":
            //        case "33333333333":
            //        case "4444444444":
            //        case "5555555555":
            //        case "6666666666":
            //        case "7777777777":
            //        case "8888888888":
            //        case "9999999999":


            //            TempData["err"] = "کد ملی وارد شده صحیح نمی باشد";
            //            nationalCodValid = false;
            //            break;

            //    }
            //    int num3 = ((((((((numArray[0] * 10) + (numArray[1] * 9)) + (numArray[2] * 8)) + (numArray[3] * 7)) + (numArray[4] * 6)) + (numArray[5] * 5)) + (numArray[6] * 4)) + (numArray[7] * 3)) + (numArray[8] * 2);
            //    int num4 = num3 - ((num3 / 11) * 11);
            //    if ((((num4 == 0) && (num2 == num4)) || ((num4 == 1) && (num2 == 1))) || ((num4 > 1) && (num2 == Math.Abs((int)(num4 - 11)))) && cunt <= 10)
            //    {



            //        nationalCodValid = true;


            //    }
            //    else
            //    {

            //        TempData["notok"] = "کد ملی وارد شده نا معتبر است";
            //        nationalCodValid = false;
            //    }
            //}
            //catch (Exception)
            //{

            //    TempData["notvalid"] = "لطفا کد ملی 10 رقمی وارد کنید";
            //    nationalCodValid = false;

            //}

            //if (idnumberIsOk && nationalCodValid && nameIsOk && nationalcodeIsOk)
            //{

            //    TempData["nullL1"] = null;
            //    TempData["personOk"] = "true";
            //    TempData["ColP1"] = "in";
            //    TempData["nullP"] = "true";
            //    TempData["Success"] = "ثبت طرف حساب جدید با موفقیت انجام شد";
            //    _PersonalContractingPartyApp.Create(command);
            //    return RedirectToPage("./Index");

            //}
            //else
            //{
            //    TempData["nullL2"] = null;
            //    TempData["personOk2"] = "true";
            //    TempData["nullP2"] = "true";
            //    TempData["ColP2"] = "in";
            //    return RedirectToPage("./Index", command);
            //}







        }


        public IActionResult OnPostInsertLegal(CreatePersonalContractingParty command)
        {


            var result2 = _PersonalContractingPartyApp.CreateLegals(command);
            return new JsonResult(result2);






        }


        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _PersonalContractingPartyApp.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public IActionResult OnGetLegalEdit(long id)
        {
            var legaly = _PersonalContractingPartyApp.GetDetails(id);
            return Partial("LegalEdit", legaly);
        }

        public JsonResult OnPostEdit(EditPersonalContractingParty command)
        {

            if (ModelState.IsValid)
            {

            }



            var result = _PersonalContractingPartyApp.Edit(command);
            return new JsonResult(result);



        }
        public JsonResult OnPostLegalEdit(EditPersonalContractingParty command)
        {

            if (ModelState.IsValid)
            {

            }



            var result = _PersonalContractingPartyApp.EditLegal(command);
            return new JsonResult(result);



        }
        public IActionResult OnGetDetails(long id)
        {
            var productCategory = _PersonalContractingPartyApp.GetDetails(id);
            return Partial("Details", productCategory);
        }
        public IActionResult OnGetLegalDetails(long id)
        {
            var legaldetails = _PersonalContractingPartyApp.GetDetails(id);
            return Partial("LegalDetails", legaldetails);
        }

      
    }
}
