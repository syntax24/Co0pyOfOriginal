using System.Collections.Generic;

namespace Company.Domain.BoardType
{
    public class BoardType
    {
        public BoardType(string title)
        {
            Title = title;
            BoardsList = new List<Board.Board>();
            PetitionsList = new List<Petition.Petition>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Board.Board> BoardsList { get; set; }
        public List<Petition.Petition> PetitionsList { get; set; }

        public void Edit(string title)
        {
            Title = title;
        }
    }
}
