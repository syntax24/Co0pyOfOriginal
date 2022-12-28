using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.EmployeeChildrenAgg;
using Company.Domain.LeftWorkAgg;

namespace Company.Domain.EmployeeAgg
{
    public class Employee : EntityBase
    {
        public Employee(string fName, string lName, string fatherName,
            DateTime dateOfBirth, DateTime dateOfIssue, string placeOfIssue,
            string nationalCode, string idNumber, string gender, string nationality,
            string phone, string address, string state, string city,
            string maritalStatus, string militaryService, string levelOfEducation, string fieldOfStudy,
            string bankCardNumber, string bankBranch, string insuranceCode, string insuranceHistoryByYear,
            string insuranceHistoryByMonth, string numberOfChildren,string officePhone,
            string mclsUserName, string mclsPassword, string eserviceUserName, string eservicePassword, string taxOfficeUserName, string taxOfficepassword, string sanaUserName, string sanaPassword)
        {
            FName = fName;
            LName = lName;
            FatherName = fatherName;


            DateOfBirth = dateOfBirth;


            DateOfIssue = dateOfIssue;
           
            PlaceOfIssue = placeOfIssue;
            NationalCode = nationalCode;
            IdNumber = idNumber;
            Gender = gender;
            Nationality = nationality;
            Phone = phone;
            Address = address;
            State = state;
            City = city;
            IsActive = true;
            IsActiveString = "true";
            MaritalStatus = maritalStatus;
            MilitaryService = militaryService;
            LevelOfEducation = levelOfEducation;
            FieldOfStudy = fieldOfStudy;
            BankCardNumber = bankCardNumber;
            BankBranch = bankBranch;
            InsuranceCode = insuranceCode;
            InsuranceHistoryByYear = insuranceHistoryByYear;
            InsuranceHistoryByMonth = insuranceHistoryByMonth;
            NumberOfChildren = numberOfChildren;
            OfficePhone = officePhone;

            MclsUserName = mclsUserName;
            MclsPassword = mclsPassword;
            EserviceUserName = eserviceUserName;
            EservicePassword = eservicePassword;
            TaxOfficeUserName = taxOfficeUserName;
            TaxOfficepassword = taxOfficepassword;
            SanaUserName = sanaUserName;
            SanaPassword = sanaPassword;
        }

 

        public string FName { get; private set; }
        public string LName { get; private set; }

        public string FatherName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public DateTime DateOfIssue { get; private set; }

        public string PlaceOfIssue { get; private set; }
        public string NationalCode { get; private set; }

        public string IdNumber { get; private set; }
        public string Gender { get; private set; }
        public string Nationality { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public bool IsActive { get; private set; }
        public string IsActiveString { get; set; }
        public string MaritalStatus { get; private set; }
        public string MilitaryService { get; private set; }
        public string LevelOfEducation { get; private set; }
        public string FieldOfStudy { get; private set; }
        public string BankCardNumber { get; private set; }
        public string BankBranch { get; private set; }
        public string InsuranceCode { get; private set; }
        public string InsuranceHistoryByYear { get; private set; }
        public string InsuranceHistoryByMonth { get; private set; }
        public string NumberOfChildren { get; private set; }
        public string OfficePhone { get; private set; }

        public string MclsUserName { get; private set; }

        public string MclsPassword { get; private set; }

        public string EserviceUserName { get; private set; }

        public string EservicePassword { get; private set; }

        public string TaxOfficeUserName { get; private set; }

        public string TaxOfficepassword { get; private set; }

        public string SanaUserName { get; private set; }
        public string SanaPassword { get; private set; }

        public List<EmployeeChildren> EmployeeChildrenList { get; private set; }
        public List<Contract> Contracts { get; private set; }
        public List<LeftWork> LeftWorks { get; set; }

        public Employee()
        {
            EmployeeChildrenList = new List<EmployeeChildren>();
            Contracts = new List<Contract>();
            LeftWorks = new List<LeftWork>();
        }

        public void Edit(string fName, string lName, string fatherName,
            DateTime dateOfBirth, DateTime dateOfIssue, string placeOfIssue,
            string nationalCode, string idNumber, string gender, string nationality,
            string phone, string address, string state, string citi,
            string maritalStatus, string militaryService, string levelOfEducation, string fieldOfStudy,
            string bankCardNumber, string bankBranch, string insuranceCode, string insuranceHistoryByYear,
            string insuranceHistoryByMonth, string numberOfChildren, string officePhone,
            string mclsUserName, string mclsPassword, string eserviceUserName, string eservicePassword, string taxOfficeUserName, string taxOfficepassword, string sanaUserName, string sanaPassword)
        {
            FName = fName;
            LName = lName;
            FatherName = fatherName;


            DateOfBirth = dateOfBirth;


            DateOfIssue = dateOfIssue;

            PlaceOfIssue = placeOfIssue;
            NationalCode = nationalCode;
            IdNumber = idNumber;
            Gender = gender;
            Nationality = nationality;
            Phone = phone;
            Address = address;
            State = state;
            City = citi;
            MaritalStatus = maritalStatus;
            MilitaryService = militaryService;
            LevelOfEducation = levelOfEducation;
            FieldOfStudy = fieldOfStudy;
            BankCardNumber = bankCardNumber;
            BankBranch = bankBranch;
            InsuranceCode = insuranceCode;
            InsuranceHistoryByYear = insuranceHistoryByYear;
            InsuranceHistoryByMonth = insuranceHistoryByMonth;
            NumberOfChildren = numberOfChildren;
            OfficePhone = OfficePhone;
            MclsUserName = mclsUserName;
            MclsPassword = mclsPassword;
            EserviceUserName = eserviceUserName;
            EservicePassword = eservicePassword;
            TaxOfficeUserName = taxOfficeUserName;
            TaxOfficepassword = taxOfficepassword;
            SanaUserName = sanaUserName;
            SanaPassword = sanaPassword;
        }

        public void Active()
        {
            this.IsActive = true;
            this.IsActiveString = "true";
        }

        public void DeActive()
        {
            this.IsActive = false;
            this.IsActiveString = "false";
        }
    }
}
