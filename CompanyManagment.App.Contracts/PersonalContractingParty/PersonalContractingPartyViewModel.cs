namespace CompanyManagment.App.Contracts.PersonalContractingParty
{
    public class PersonalContractingPartyViewModel
    {
        public long id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Nationalcode { get; set; }

        public string IdNumber { get; set; }
        //public string LegalName { get; set; }
        public string RegisterId { get; set; }

        public string NationalId { get; set; }

        public string IsLegal { get; set; }
        public string Phone { get; set; }

        public string AgentPhone { get; set; }

        public string Address { get; set; }

        public string CreationDate { get; set; }

        

        public long ContractsCount { get; set; }

        public long WorkshopsCount { get; set; }

    }
}