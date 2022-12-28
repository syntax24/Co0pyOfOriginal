using _0_Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Domain.ProceedingSession
{
    public class ProceedingSession : EntityBase
    {
        public ProceedingSession(DateTime date, string time,long board_Id)
        {
            Date = date;
            Time = time;
            Board_Id = board_Id;
            //Status = status;
        }

        public DateTime Date { get; private set; }
        public string Time { get; private set; }
        public long Board_Id { get; private set; }
        //public int Status { get; private set; } // 1-> udone , 2-> done
        public Board.Board Board { get; private set; }

        public void Edit(DateTime date, string time, long board_Id)
        {
            Date = date;
            Time = time;
            Board_Id = board_Id;
            //Status = status;
        }
    }
}
