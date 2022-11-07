namespace CompanyManagment.App.Contracts.Employer
{
    public class EmployerViewModel
    {
        public long Id { get; set; }
        public string FName { get; set; }   
        public string LName { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Nationalcode { get; set; }

        public string IdNumber { get; set; }

        public string Nationality { get; set; }

        public string FatherName { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfIssue { get; set; }

        public string PlaceOfIssue { get; set; }



        public string RegisterId { get; set; }

        public string NationalId { get; set; }


        public string EmployerLName { get; set; }

        public string IsLegal { get; set; }
        public string Phone { get; set; }

        public string AgentPhone { get; set; }

        public string Address { get; set; }

        public long ContractingPartyID { get; set; }
        public string ContractingParty { get; set; }

        public string MclsUserName { get; set; }

        public string MclsPassword { get; set; }

        public string EserviceUserName { get; set; }

        public string EservicePassword { get; set; }

        public string TaxOfficeUserName { get; set; }

        public string TaxOfficepassword { get; set; }
        public string SanaUserName { get; set; }
        public string SanaPassword { get; set; }

        public bool IsActive { get; set; }

        public string EmployerNo { get; set; }
    }
}