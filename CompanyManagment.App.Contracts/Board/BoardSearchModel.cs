namespace CompanyManagment.App.Contracts.Board
{
    public class BoardSearchModel
    {
        //public string DisputeResolutionPetitionFromDate { get; set; }

        //public string DisputeResolutionPetitionToDate { get; set; }
        public long Id { get; set; }
        public string Branch { get; set; }
        //public string BoardChairman { get; set; }

        //public string ExpertReport { get; set; }
        public long File_Id { get; set; }
        public long BoardType_Id { get; set; }

    }
}