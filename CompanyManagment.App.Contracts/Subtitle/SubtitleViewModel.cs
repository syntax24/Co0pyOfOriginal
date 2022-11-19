
namespace CompanyManagment.App.Contracts.Subtitle
{

    public class SubtitleViewModel
    {
        public long Id { get; set; }
        public string Subtitle { get; set; }
        public long OriginalTitle_Id { get; set; }
        public string OriginalTitle  { get; set; }
        public string IsActiveString { get; set; }
    }
}
