using System.Collections.Generic;
using _0_Framework.Domain;
using Company.Domain.empolyerAgg;

namespace Company.Domain.ContarctingPartyAgg
{
    public class PersonalContractingParty : EntityBase
    {
        //public long Id { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }

        public string Nationalcode { get; private set; }

        public string IdNumber { get; private set; }

        //public string LegalName { get; set; }

        public string RegisterId { get; private set; }

        public string NationalId { get; private set; }

        public string IsLegal { get; private set; }
        public string Phone { get; private set; }

        public string AgentPhone { get; private set; }

        public string Address { get; private set; }

        public List<Employer> Employers { get; private set; }

        public PersonalContractingParty()
        {
            Employers = new List<Employer>();
        }
        public PersonalContractingParty(string fName, string lName, string nationalcode, string idNumber,
            /*string legalName,*/ string registerId, string nationalId, string isLegal,
            string phone, string agentPhone, string address)
        {

            FName = fName;
            LName = lName;
            Nationalcode = nationalcode;
            IdNumber = idNumber;
            //LegalName = legalName;
            RegisterId = registerId;
            NationalId = nationalId;
            IsLegal = isLegal;
            Phone = phone;
            AgentPhone = agentPhone;
            Address = address;
        }




        public void Edit(string fName, string lName, string nationalcode, string idNumber,
            string phone, string agentPhone, string address)
        {

            FName = fName;
            LName = lName;
            Nationalcode = nationalcode;
            IdNumber = idNumber;
            Phone = phone;
            AgentPhone = agentPhone;
            Address = address;
        }

        public void EditLegal(string lName, string registerId, string nationalId, string phone, string agentPhone, string address)
        {

            LName = lName;
            RegisterId = registerId;
            NationalId = nationalId;
            Phone = phone;
            AgentPhone = agentPhone;
            Address = address;

        }

        public void Edit2(string address)
        {
            Address = address;
        }
    }
}

