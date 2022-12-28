
using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace Company.Domain.Evidence
{
    public class Evidence : EntityBase
    {
        public Evidence(string description, int boardType_Id, long file_Id)
        {
            
            Description = description;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
            EvidenceDetailsList = new List<EvidenceDetail.EvidenceDetail>();
        }

        public string Description { get; set; }
        public int BoardType_Id { get; set; }
        public long File_Id { get; set; }

        public File1.File1 File1 { get; private set; }
        public BoardType.BoardType BoardType { get; private set; }

        public List<EvidenceDetail.EvidenceDetail> EvidenceDetailsList { get; set; }

        public void Edit(string description, int boardType_Id, long file_Id)
        {
            Description = description;
            BoardType_Id = boardType_Id;
            File_Id = file_Id;
        }
    }
}