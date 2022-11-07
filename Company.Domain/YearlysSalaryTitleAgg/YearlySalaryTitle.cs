using _0_Framework.Domain;

namespace Company.Domain.YearlysSalaryTitleAgg
{
    public class YearlySalaryTitle :EntityBase
    {
        public YearlySalaryTitle(string title1, string title2, string title3, string title4, string title5, string title6, string title7, string title8, string title9, string title10)
        {
            Title1 = title1;
            Title2 = title2;
            Title3 = title3;
            Title4 = title4;
            Title5 = title5;
            Title6 = title6;
            Title7 = title7;
            Title8 = title8;
            Title9 = title9;
            Title10 = title10;
        }

        public string Title1 { get; private set; }
        public string Title2 { get; private set; }
        public string Title3 { get; private set; }
        public string Title4 { get; private set; }
        public string Title5 { get; private set; }
        public string Title6 { get; private set; }
        public string Title7 { get; private set; }
        public string Title8 { get; private set; }
        public string Title9 { get; private set; }
        public string Title10 { get; private set; }


        public void Edit(string title1, string title2, string title3, string title4, string title5, string title6, string title7, string title8, string title9, string title10)
        {
            Title1 = title1;
            Title2 = title2;
            Title3 = title3;
            Title4 = title4;
            Title5 = title5;
            Title6 = title6;
            Title7 = title7;
            Title8 = title8;
            Title9 = title9;
            Title10 = title10;
        }
    }

    
}
