using _0_Framework.Domain;
using System.Collections.Generic;
using Company.Domain.SubtitleAgg;

namespace Company.Domain.OriginalTitleAgg
{
    public class EntityOriginalTitle : EntityBase
    {
        public EntityOriginalTitle(string title)
        {
            Title = title;
       
        }
        public string Title { get; private set; }
        public string IsActiveString { get; set; }
        public List< EntitySubtitle> Subtitles { get; private set; }

        public EntityOriginalTitle()
        {
            Subtitles = new List<EntitySubtitle>(); 
        }
        public void Edit(string title)
        {
            Title = title;
      
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
