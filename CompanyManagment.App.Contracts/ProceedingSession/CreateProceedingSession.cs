namespace CompanyManagment.App.Contracts.ProceedingSession
{
    public class CreateProceedingSession
    {
        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string Date { get; set; }

        //[Required(ErrorMessage = "فیلد الزامی است")]
        public string Time { get; set; }
        public long Board_Id { get; set; }
        //public int Status { get; set; }
    }
}
