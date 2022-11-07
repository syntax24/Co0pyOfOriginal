
using Company.Domain.ModuleAgg;
using Company.Domain.TextManagerAgg;

namespace Company.Domain.ModuleTextManagerAgg
{
    public class EntityModuleTextManager
    {

        public long ModuleId { get;  set; }
       public  EntityModule Module { get;  set; }

        public long TextManagerId { get;  set; }
        public  EntityTextManager  TextManager { get;  set; }

    }
}
