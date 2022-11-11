namespace CompanyManagment.App.Contracts.TextManager
{

    public class TextManagerSearchModel
    {
        public int NoteNumber { get;  set; }
        public string SubjectTextManager { get; set; }
        public int NumberTextManager { get; set; }
        public string DateTextManager { get; set; }
        public string Description { get; set; }
        public string Paragraph { get; set; }
        public byte Status { get; set; }
        public long OriginalTitle_Id { get; set; }
        public long Subtitle_Id { get; set; }
        public long Chapter_Id { get; set; }

    }
 
}
