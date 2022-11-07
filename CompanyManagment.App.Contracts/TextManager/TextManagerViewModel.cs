
using System.Collections.Generic;

namespace CompanyManagment.App.Contracts.TextManager
{

    public class TextManagerViewModel
    {

        public long Id { get; set; }
        public int NoteNumber { get; set; }
        public string SubjectTextManager { get; set; }
        public int NumberTextManager { get; set; }
        public string DateTextManager { get; set; }
        public string Description { get; set; }
        public string Paragraph { get; set; }
        public long OriginalTitle_Id { get; set; }
        public long Subtitles_Id { get; set; }
        public byte Status { get;  set; }
        public string Subtitle { get; set; }
        public string OriginalTitle { get; set; }
        public List<string> ListUseModule { get; set; }
        //public List<string> ListAllModule { get; set; }
        //public List<OriginalTitleViewModel>  originalTitleViewModels { get; set; }
        //public List<SubtitleViewModel>  subtitleViewModels { get; set; }
    }
}
