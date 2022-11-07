using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.ContractAgg;
using Company.Domain.WorkshopEmployerAgg;



namespace Company.Domain.WorkshopAgg
{
   
    public class Workshop : EntityBase
    {
        public Workshop(string contractTerm)
        {
            ContractTerm = contractTerm;
            Contracts2 = new List<Contract>();
            WorkshopEmployers = new List<WorkshopEmployer>();
         

        }
        public Workshop(string workshopName,string workshopSureName, string insuranceCode, string typeOfOwnership, string archiveCode, string agentName, string agentPhone, 
            string state, string city, string address, string typeOfInsuranceSend, string typeOfContract, string contractTerm)
        {
            WorkshopName = workshopName;
            WorkshopSureName = workshopSureName;
            if (workshopSureName != null)
            {
                WorkshopFullName = workshopName + " (" + workshopSureName + ")";
            }
            else
            {
                WorkshopFullName = workshopName;
            }
           
            InsuranceCode = insuranceCode;
            //EmployerId = employerId;
            IsActive = true;
            IsActiveString = "true";
            TypeOfOwnership = typeOfOwnership;
            ArchiveCode = archiveCode;
            AgentName = agentName;
            AgentPhone = agentPhone;
            State = state;
            City = city;
            Address = address;
            TypeOfInsuranceSend = typeOfInsuranceSend;
            TypeOfContract = typeOfContract;
            ContractTerm = contractTerm;
        }

        public string WorkshopName { get; private set; }
        public string WorkshopSureName { get; private set; }

        public string WorkshopFullName { get; private set; }
        
        public string InsuranceCode { get; private set; }

        //public long EmployerId { get; private set; }

        public bool IsActive { get; private set; }
        public string IsActiveString { get; set; }
        public string TypeOfOwnership { get; private set; }

        public string ArchiveCode { get; private set; }

        public string AgentName { get; private set; }

        public string AgentPhone { get; private set; }

        public string State { get; private set; }

    

        public string City { get; private set; }

      

        public string Address { get; private set; }

        public string TypeOfInsuranceSend { get; private set; }

      
   

        public string TypeOfContract { get; private set; }
        public string ContractTerm { get; private set; }



       
        //public Employer Employer { get; private set; }

        public List<Contract> Contracts2 { get; set; }
        public List<WorkshopEmployer> WorkshopEmployers { get; set; }


      


        public void Edit(string workshopName, string workshopSureName, string insuranceCode,string typeOfOwnership, string archiveCode, string agentName, string agentPhone,
            string state, string city, string address, string typeOfInsuranceSend, string typeOfContract, string contractTerm)
        {
            WorkshopName = workshopName;
            WorkshopSureName = workshopSureName;
            if (workshopSureName != null)
            {
                WorkshopFullName = workshopName + " (" + workshopSureName + ")";
            }
            else
            {
                WorkshopFullName = workshopName;
            }
            InsuranceCode = insuranceCode;
            //EmployerId = employerId;
            TypeOfOwnership = typeOfOwnership;
            ArchiveCode = archiveCode;
            AgentName = agentName;
            AgentPhone = agentPhone;
            State = state;
            City = city;
            Address = address;
            TypeOfInsuranceSend = typeOfInsuranceSend;
            TypeOfContract = typeOfContract;
            ContractTerm = contractTerm;

        }


        public void Active(string archiveCode)
        {
            this.IsActive = true;
            this.IsActiveString= "true";
            string a = archiveCode;
            string bb = string.Empty;
            int convert2 = 0;
            for (int x = 0; x < a.Length; x++)
            {
                if (char.IsDigit(a[x]))
                    bb += a[x];
            }

            if (bb.Length > 0)
            {

                convert2 = int.Parse(bb);
            }

            var final = convert2.ToString();
            ArchiveCode = final;
        }

        public void DeActive(string archiveCode)
        {
            this.IsActive = false;
            this.IsActiveString = "false";
            ArchiveCode = "b-" + archiveCode;
        }
    }
    

}

