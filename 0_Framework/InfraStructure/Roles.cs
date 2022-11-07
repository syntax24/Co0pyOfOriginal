using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace _0_Framework.Infrastructure
{


    public static class Roles
    {

 

        public const string Administrator = "1";
        public static readonly IList<string> role = new ReadOnlyCollection<string>(new List<string>
        {
            "1","2","3","4","5","6","7","8","9","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",

        });

        //public const string SystemUser = "2";
        //public const string ContentUploader = "10";
        //public const string ColleagueUser = "10002";

        //public static string GetRoleBy(long id)
        //{
        //    switch (id)
        //    {
        //        case 1:
        //            return "مدیرسیستم";
        //        case 2:
        //            return "کاربر عادی";
        //        case 10:
        //            return "test 4";
        //        default:
        //            return "";
        //    }
        //}

    }
}
