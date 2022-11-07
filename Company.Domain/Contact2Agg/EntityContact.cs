using _0_Framework.Domain;

namespace Company.Domain.Contact2Agg
{
    public class EntityContact : EntityBase
    {
        public EntityContact(string nameContact)
        {
            NameContact = nameContact;

        }

        public string NameContact { get; private set; }




        public void Edit(string nameSubContact)
        {
            NameContact = nameSubContact;

        }
    }
}
