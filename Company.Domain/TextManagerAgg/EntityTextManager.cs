using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using Company.Domain.ModuleTextManagerAgg;

namespace Company.Domain.TextManagerAgg
{
    public class EntityTextManager : EntityBase
    {
        public EntityTextManager(int noteNumber, string subjectTextManager,
            int numberTextManager, DateTime dateTextManager, string description, string paragraph, long originalTitle_Id, long subtitles_Id, long chapter_Id, byte status)
        {
            NoteNumber = noteNumber;
            SubjectTextManager = subjectTextManager;
            NumberTextManager = numberTextManager;
            DateTextManager = dateTextManager;
            Description = description;
            Paragraph = paragraph;
            OriginalTitle_Id = originalTitle_Id;
            Subtitles_Id = subtitles_Id;
            Chapter_Id = chapter_Id;
            Status = status;
        }
        public int NoteNumber { get; private set; }
        public string SubjectTextManager { get; private set; }
        public int NumberTextManager { get; private set; }
        
         public DateTime DateTextManager { get; private set; }
         public string Description { get; private set; }
        public string Paragraph { get; private set; }
        public byte Status { get; private set; }
        public long OriginalTitle_Id { get; private set; }
        public long Subtitles_Id { get; private set; }
        public long Chapter_Id { get; private set; }
        public List<EntityModuleTextManager> EntityModuleTextManagers { get; private set; }


        public void Edit(int noteNumber, string subjectTextManager,
            int numberTextManager, DateTime dateTextManager, string description, string paragraph, long originalTitle_Id, long subtitles_Id, long chapter_Id, byte status)
        {
            NoteNumber = noteNumber;
            SubjectTextManager = subjectTextManager;
            NumberTextManager = numberTextManager;
            DateTextManager = dateTextManager;
            Description = description;
            Paragraph = paragraph;
            OriginalTitle_Id = originalTitle_Id;
            Subtitles_Id = subtitles_Id;
            Chapter_Id = chapter_Id;
            Status = status;
        }
    }
}
