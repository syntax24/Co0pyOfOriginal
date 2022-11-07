using _0_Framework.Domain;
using Company.Domain.OriginalTitleAgg;

namespace Company.Domain.SubtitleAgg
{
    public class EntitySubtitle : EntityBase
    {
        public EntitySubtitle(string subtitle, long originalTitle_Id)
        {
            Subtitle = subtitle;
            OriginalTitle_Id = originalTitle_Id;
        }
        public string Subtitle { get; private set; }
        public long OriginalTitle_Id { get; private set; }
        public EntityOriginalTitle EntityOriginalTitle { get; set; }
        public void Edit(string subtitle, long originalTitle_Id)
        {
            Subtitle = subtitle;
            OriginalTitle_Id = originalTitle_Id;
        }
    }
}
