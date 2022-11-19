using _0_Framework.Domain;
using System.Collections.Generic;
using Company.Domain.ModuleTextManagerAgg;


namespace Company.Domain.ModuleAgg
{
    public class EntityModule : EntityBase
    {
        public EntityModule(string nameSubModule)
        {
            NameSubModule = nameSubModule;

        }

        public string NameSubModule { get; private set; }
        public string IsActiveString { get; set; }

        public List<EntityModuleTextManager> EntityModuleTextManagers { get; private set; }

        public void Edit(string nameSubModule)
        {
            NameSubModule = nameSubModule;

        }
        public void Active()
        {

            this.IsActiveString = "true";
        }

        public void DeActive()
        {

            this.IsActiveString = "false";
        }
    }
}
