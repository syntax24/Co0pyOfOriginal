using System.ComponentModel.DataAnnotations;

namespace CompanyManagment.App.Contracts.MasterWorkHistory
{
    public class CreateMasterWorkHistory
    {
        //[Required]
        public string FromDate { get; set; }
        //[Required]
        public string ToDate { get; set; }
        public string WorkingHoursPerDay { get; set; }
        public string WorkingHoursPerWeek { get; set; }
        public string Description { get; set; }
        public long MasterPetition_Id { get; set; }
    }
}
