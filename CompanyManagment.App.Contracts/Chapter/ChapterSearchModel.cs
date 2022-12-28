

namespace CompanyManagment.App.Contracts.Chapter
{

    public class ChapterSearchModel
    {
        public string Chapter { get; set; }
        public long Subtitle_Id { get; set; }
        public string Subtitle { get; set; }
        public long OriginalTitle_Id { get; set; }
        public string OriginalTitle { get; set; }
        public string IsActiveString { get; set; }
    }
 
}
