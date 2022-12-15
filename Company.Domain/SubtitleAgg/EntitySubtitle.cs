using _0_Framework.Domain;
using Company.Domain.ChapterAgg;
using Company.Domain.OriginalTitleAgg;
using System.Collections.Generic;

namespace Company.Domain.SubtitleAgg
{
    public class EntitySubtitle : EntityBase
    {
        public EntitySubtitle(string subtitle, long originalTitle_Id)
        {
            Subtitle = subtitle;
            OriginalTitle_Id = originalTitle_Id;
            IsActiveString = "true";
        }
        public string Subtitle { get; private set; }
        public long OriginalTitle_Id { get; private set; }
        public string IsActiveString { get; set; }
        public EntityOriginalTitle EntityOriginalTitle { get; set; }

        public List<EntityChapter> Chapters { get; private set; }

        public EntitySubtitle()
        {
            Chapters = new List<EntityChapter>();
        }

        public List<EntitySubtitle> Subtitles { get; private set; }

        
        public void Edit(string subtitle, long originalTitle_Id)
        {
            Subtitle = subtitle;
            OriginalTitle_Id = originalTitle_Id;
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
