using _0_Framework.Domain;

namespace Company.Domain.Contact2Agg
{
    public class EntityContact : EntityBase
    {
        public EntityContact(string nameContact)
        {
            NameContact = nameContact;
            IsActiveString = "true";
           Signature = "0";
        }

        public string NameContact { get; private set; }
        public string IsActiveString { get; private set; }
        public string Signature { get; private set; }


        public void Edit(string nameSubContact)
        {
            NameContact = nameSubContact;

        }
        public void Active()
        {

            this.IsActiveString = "true";
        }

        public void DeActive()
        {

            this.IsActiveString = "false";
        }

        public void Sign()
        {
            this.Signature = "1";
        }

        public void UnSign()
        {
            this.Signature = "0";
        }
    }
}
