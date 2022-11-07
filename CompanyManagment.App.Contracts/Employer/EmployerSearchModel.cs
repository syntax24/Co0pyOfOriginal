namespace CompanyManagment.App.Contracts.Employer
{
    public class EmployerSearchModel
    {
        public string FName { get; set; }
        public string LName { get; set; }

        public string FullName { get; set; }
        public string Gender { get; set; }

        public string Nationalcode { get; set; }

        public string IdNumber { get; set; }



        public string RegisterId { get; set; }

        public string NationalId { get; set; }


        public string EmployerLName { get; set; }

        public string IsLegal { get; set; }

        public long ContractingPartyID { get; set; }

        public bool IsActive { get; set; }

        public string Address { get; set; }



    }
}