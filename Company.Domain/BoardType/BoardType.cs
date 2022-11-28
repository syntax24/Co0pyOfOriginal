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

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Board.Board> BoardsList { get; set; }
        public List<Petition.Petition> PetitionsList { get; set; }
        public List<MasterPetition.MasterPetition> MasterPetitionsList { get; set; }

        public void Edit(string title)
        {
            Title = title;
        }
    }
}
