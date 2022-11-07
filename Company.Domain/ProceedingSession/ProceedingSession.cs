using _0_Framework.Domain;
using System;

namespace Company.Domain.ProceedingSession
{
    public class ProceedingSession : EntityBase
    {
        public ProceedingSession(DateTime date, string time,long board_Id)
        {
            Date = date;
            Time = time;
            Board_Id = board_Id;
        }

        public DateTime Date { get; private set; }
        public string Time { get; private set; }
        public long Board_Id { get; private set; }
        public Board.Board Board { get; set; }

        public void Edit(DateTime date, string time, long board_Id)
        {
            Date = date;
            Time = time;
            Board_Id = board_Id;
        }
    }
}
