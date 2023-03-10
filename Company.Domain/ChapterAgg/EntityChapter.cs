using _0_Framework.Domain;
using Company.Domain.OriginalTitleAgg;
using Company.Domain.SubtitleAgg;

namespace Company.Domain.ChapterAgg
{
    public class EntityChapter : EntityBase
    {
        public EntityChapter(string chapter, long subtitle_Id)
        {
            Chapter = chapter;
            Subtitle_Id = subtitle_Id;
           IsActiveString = "true";
        }
        public string Chapter { get; private set; }
        public long Subtitle_Id { get; private set; }
        public string IsActiveString { get; set; }
        public EntitySubtitle EntitySubtitle { get; set; }

        public void Edit(string chapter, long subtitle_Id)
        {
            Chapter = chapter;
            Subtitle_Id = subtitle_Id;
        }
        public void Active()
        {

            this.IsActiveString = "true";
        }

        public void DeActive()
        {

            this.IsActiveString = "false";
        }
    }
}
