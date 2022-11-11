using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using Company.Domain.ModuleTextManagerAgg;

namespace Company.Domain.TextManagerAgg
{
    public class EntityTextManager : EntityBase
    {
        public EntityTextManager(int noteNumber, string subjectTextManager,
            int numberTextManager, DateTime dateTextManager, string description, string paragraph, long originalTitle_Id, long subtitle_Id, long chapter_Id)
        {
            NoteNumber = noteNumber;
            SubjectTextManager = subjectTextManager;
            NumberTextManager = numberTextManager;
            DateTextManager = dateTextManager;
            Description = description;
            Paragraph = paragraph;
            OriginalTitle_Id = originalTitle_Id;
            Subtitle_Id = subtitle_Id;
            Chapter_Id = chapter_Id;
            IsActiveString = "true";
            Signature = "0";

        }
        public int NoteNumber { get; private set; }
        public string SubjectTextManager { get; private set; }
        public int NumberTextManager { get; private set; }
        
         public DateTime DateTextManager { get; private set; }
         public string Description { get; private set; }
        public string Paragraph { get; private set; }
        public string IsActiveString { get; set; }
        public string Signature { get; set; }
        public long OriginalTitle_Id { get; private set; }
        public long Subtitle_Id { get; private set; }
        public long Chapter_Id { get; private set; }
        public List<EntityModuleTextManager> EntityModuleTextManagers { get; private set; }


        public void Edit(int noteNumber, string subjectTextManager,
            int numberTextManager, DateTime dateTextManager, string description, string paragraph, long originalTitle_Id, long subtitle_Id, long chapter_Id)
        {
            NoteNumber = noteNumber;
            SubjectTextManager = subjectTextManager;
            NumberTextManager = numberTextManager;
            DateTextManager = dateTextManager;
            Description = description;
            Paragraph = paragraph;
            OriginalTitle_Id = originalTitle_Id;
            Subtitle_Id = subtitle_Id;
            Chapter_Id = chapter_Id;
           
        }
        public void Active()
        {

            this.IsActiveString = "true";
        }

        public void DeActive()
        {

            this.IsActiveString = "false";
        }

        public void Sign()
        {
            this.Signature = "1";
        }

        public void UnSign()
        {
            this.Signature = "0";
        }
    }
}
