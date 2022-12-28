using System;

namespace _0_Framework_b.Domain
{
    public class EntityBase
    {
        public long id { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
            CreationDate=DateTime.Now;
            
        }
    }
}
