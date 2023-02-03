namespace CompanyManagment.App.Contracts.Board
{
    public class CreateBoard
    {
        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string DisputeResolutionPetitionDate { get; set; }

        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string Branch { get; set; }

        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string BoardChairman { get; set; }

        public string ExpertReport { get; set; }
        public long File_Id { get; set; }
        public int BoardType_Id { get; set; }

    }
}
