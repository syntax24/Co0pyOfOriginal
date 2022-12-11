using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.BoardType
{
    public class BoardType
    {
        public BoardType(string title)
        {
            Title = title;
            BoardsList = new List<Board.Board>();
            PetitionsList = new List<Petition.Petition>();
            MasterPetitionsList = new List<MasterPetition.MasterPetition>();
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public List<Board.Board> BoardsList { get; private set; }
        public List<Petition.Petition> PetitionsList { get; private set; }
        public List<MasterPetition.MasterPetition> MasterPetitionsList { get; private set; }
        public List<Evidence.Evidence> EvidencesList { get; private set; }

        public void Edit(string title)
        {
            Title = title;
        }
    }
}
