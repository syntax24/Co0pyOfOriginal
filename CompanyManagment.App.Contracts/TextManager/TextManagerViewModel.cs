
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.TextManager
{

    public class TextManagerViewModel
    {

        public long Id { get; set; }
        public string NoteNumber { get; set; }
        public string SubjectTextManager { get; set; }
        public string NumberTextManager { get; set; }
        public string DateTextManager { get; set; }
        public string Description { get; set; }
        public string Paragraph { get; set; }
        public long OriginalTitle_Id { get; set; }
        public long Subtitle_Id { get; set; }
        public long Chapter_Id { get; set; }
        public string IsActiveString { get; set; }
        public string Signature { get; set; }

        public string Subtitle { get; set; }
        public string Chapter { get; set; }
        public string OriginalTitle { get; set; }
        public List<string> ListUseModule { get; set; }
        public string SubtitleIsActiveString { get; set; }
        public string ChapterActiveString { get; set; }
        public string OriginalTitleActiveString { get; set; }
        //public List<string> ListAllModule { get; set; }
        //public List<OriginalTitleViewModel>  originalTitleViewModels { get; set; }
        //public List<SubtitleViewModel>  subtitleViewModels { get; set; }
    }
}
