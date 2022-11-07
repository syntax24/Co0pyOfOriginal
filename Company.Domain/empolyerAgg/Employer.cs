using System;
using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.ContarctingPartyAgg;
using Company.Domain.ContractAgg;
using Company.Domain.WorkshopEmployerAgg;

namespace Company.Domain.empolyerAgg
{
   
    public class Employer : EntityBase
    {
       
        public string FName { get; private set; }
        public string LName { get; private set; }

        public string FullName { get; private set; }

        public long ContractingPartyId { get; private set; }

        public bool IsActive { get; private set; }
        public string Gender { get; private set; }

        public string Nationalcode { get; private set; }

        public string IdNumber { get; private set; }

        public string Nationality { get; private set; }

        public string FatherName { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public DateTime DateOfIssue { get; private set; }

        public string PlaceOfIssue { get; private set; }

      

        public string RegisterId { get; private set; }

        public string NationalId { get; private set; }

      
        public string EmployerLName { get; private set; }

        public string IsLegal { get; private set; }
        public string Phone { get; private set; }

        public string AgentPhone { get; private set; }

        public string Address { get; private set; }

        public string MclsUserName { get; private set; }

        public string MclsPassword { get; private set; }

        public string EserviceUserName { get; private set; }

        public string EservicePassword { get; private set; }

        public string TaxOfficeUserName { get; private set; }

        public string TaxOfficepassword { get; private set; }
        public string SanaUserName { get; private set; }
        public string SanaPassword { get; private set; }

        public string EmployerNo { get; set; }
        public PersonalContractingParty ContractingParty { get; set; }

        //public List<Workshop> Workshops { get; private set; }
        public List<Contract> Contracts { get; private set; }
        public List<WorkshopEmployer> WorkshopEmployers { get; set; }
        public Employer()
        {
            //Workshops = new List<Workshop>();
            Contracts = new List<Contract>();
            WorkshopEmployers = new List<WorkshopEmployer>();
        }

        public Employer(string fName, string lName, long contractingPartyId,string gender, string nationalcode, string idNumber, string nationality, string fatherName,
            DateTime dateOfBirth, DateTime dateOfIssue, string placeOfIssue, string registerId, string nationalId, string employerLName, string isLegal, string phone, 
            string agentPhone, string address, string mclsUserName, string mclsPassword, string eserviceUserName, string eservicePassword, string taxOfficeUserName,
            string taxOfficepassword, string sanaUserName, string sanaPassword)
        {
            FName = fName;
            LName = lName;
            if (isLegal == "حقیقی")
            {
                FullName = fName + " " + lName;
            }
            else
            {
                FullName = lName;
            }
            
            ContractingPartyId = contractingPartyId;
            IsActive = true;
            Gender = gender;
            Nationalcode = nationalcode;
            IdNumber = idNumber;
           
            Nationality = nationality;

            FatherName = fatherName;

            DateOfBirth = dateOfBirth;
            DateOfIssue = dateOfIssue;

            PlaceOfIssue = placeOfIssue;
            RegisterId = registerId;
            NationalId = nationalId;
            EmployerLName = employerLName;
            IsLegal = isLegal;
            Phone = phone;
            AgentPhone = agentPhone;
            Address = address;

            MclsUserName = mclsUserName;
            MclsPassword = mclsPassword;
            EserviceUserName = eserviceUserName;
            EservicePassword = eservicePassword;
            TaxOfficeUserName = taxOfficeUserName;
            TaxOfficepassword = taxOfficepassword;
            SanaUserName = sanaUserName;
            SanaPassword = sanaPassword;

           

        }

        public void Edit(string fName, string lName, long contractingPartyId, string gender, string nationalcode, string idNumber, string nationality, string fatherName, DateTime dateOfBirth, DateTime dateOfIssue, string placeOfIssue,
            string phone, string agentPhone, string mclsUserName, string mclsPassword, string eserviceUserName, string eservicePassword, string taxOfficeUserName,
            string taxOfficepassword, string sanaUserName, string sanaPassword, string employerno)
        {
            FName = fName;
            LName = lName;
            FullName = fName + " " + lName;
            ContractingPartyId = contractingPartyId;
            //IsActive = isActive;
            Gender = gender;
            Nationalcode = nationalcode;
            IdNumber = idNumber;
            Nationality = nationality;
            FatherName = fatherName;

            DateOfBirth = dateOfBirth;
            DateOfIssue = dateOfIssue;

            PlaceOfIssue = placeOfIssue;
          
          
          
            Phone = phone;
            AgentPhone = agentPhone;
           

            MclsUserName = mclsUserName;
            MclsPassword = mclsPassword;
            EserviceUserName = eserviceUserName;
            EservicePassword = eservicePassword;
            TaxOfficeUserName = taxOfficeUserName;
            TaxOfficepassword = taxOfficepassword;
            SanaUserName = sanaUserName;
            SanaPassword = sanaPassword;

            EmployerNo = employerno;

        }

        public void EditLegal(string fName, string lName, long contractingPartyId, string gender, string nationalcode, string idNumber, string nationality, string fatherName, DateTime dateOfBirth, DateTime dateOfIssue, string placeOfIssue, string registerId, string nationalId, string employerLName, string phone, 
            string agentPhone,  string mclsUserName, string mclsPassword, string eserviceUserName, string eservicePassword, string taxOfficeUserName,
            string taxOfficepassword, string sanaUserName, string sanaPassword, string employerno)
        {
            FName = fName;
            LName = lName;
            FullName = lName;
            ContractingPartyId = contractingPartyId;
            //IsActive = isActive;
            Gender = gender;
            Nationalcode = nationalcode;
            IdNumber = idNumber;
            Nationality = nationality;
            FatherName = fatherName;



            DateOfBirth = dateOfBirth;
            DateOfIssue = dateOfIssue;

            PlaceOfIssue = placeOfIssue;
            RegisterId = registerId;
            NationalId = nationalId;
            EmployerLName = employerLName;
        
            Phone = phone;
            AgentPhone = agentPhone;
           

            MclsUserName = mclsUserName;
            MclsPassword = mclsPassword;
            EserviceUserName = eserviceUserName;
            EservicePassword = eservicePassword;
            TaxOfficeUserName = taxOfficeUserName;
            TaxOfficepassword = taxOfficepassword;
            SanaUserName = sanaUserName;
            SanaPassword = sanaPassword;

            EmployerNo = employerno;

        }

        public void EditEmployerNo(string employerNo)
        {
            EmployerNo = employerNo;
        }
        public void Active()
        {
            this.IsActive = true;
            this.Address = "true";
        }

        public void DeActive()
        {
            this.IsActive = false;
            this.Address = "false";
        }
    }
    

}

