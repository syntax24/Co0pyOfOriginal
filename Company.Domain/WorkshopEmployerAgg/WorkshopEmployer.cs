using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using Company.Domain.empolyerAgg;
using Company.Domain.WorkshopAgg;

namespace Company.Domain.WorkshopEmployerAgg
{
    public class WorkshopEmployer 
    {

        public long WorkshopId { get;  set; }
        public Workshop Workshop { get;  set; }

        public long EmployerId { get;  set; }
        public Employer Employer { get;  set; }
       
    }
}
