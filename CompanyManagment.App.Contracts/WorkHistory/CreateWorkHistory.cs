using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.WorkHistory
{
    public class CreateWorkHistory
    {
        //[Required]
        public string FromDate { get; set; }
        //[Required]
        public string ToDate { get; set; }
        public string WorkingHoursPerDay { get; set; }
        public string WorkingHoursPerWeek { get; set; }
        public string Description { get; set; }
        public long Petition_Id { get; set; }
    }
}
