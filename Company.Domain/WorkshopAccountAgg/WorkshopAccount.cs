
using Company.Domain.WorkshopAgg;

namespace Company.Domain.WorkshopAccountAgg
{
    public class WorkshopAccount
    {
        public long WorkshopId { get; set; }
        public Workshop Workshop { get; set; }
        public long AccountId { get; set; }

       
    }
}
