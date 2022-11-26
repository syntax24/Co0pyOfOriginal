using System;
using System.Globalization;

namespace _0_Framework_b.Application
{
    public static class Tools
    {
        
        public static string[] MonthNames =
            {"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"};

        public static string[] DayNames = {"شنبه", "یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه"};
        public static string[] DayNamesG = {"یکشنبه", "دو شنبه", "سه شنبه", "چهار شنبه", "پنج شنبه", "جمعه", "شنبه"};


        public static string ToFarsi(this DateTime? date)
        {
            try
            {
                if (date != null) return date.Value.ToFarsi();
            }
            catch (Exception)
            {
                return "";
            }

            return "";
        }

        public static string ToFarsi(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
        }
        public static string ToFarsiMonth(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            return $"{pc.GetMonth(date)}";
        }

        public static string ToFarsiYear2(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();
            var year = pc.GetYear(date).ToString();
            string y1 = string.Empty;
            string y2 = string.Empty;
            string sum=string.Empty;
            for (int i = 0; i < year.Length; i++)
            {

                if (year[i] == 2)
                {
                    y1 += year[i];
                }

                if (year[i]==3)
                {
                    y2 += year[i];
                }
                
            }

            sum = y1 + y2;
            return sum;
        }
        public static string ToFarsiYear(this DateTime date)
        {
            if (date == new DateTime()) return "";
            var pc = new PersianCalendar();

            return $"{pc.GetYear(date)}";
        }
        public static string ToDiscountFormat(this DateTime date)
        {
            if (date == new DateTime()) return "";
            return $"{date.Year}/{date.Month}/{date.Day}";
        }

        public static string GetTime(this DateTime date)
        {
            return $"_{date.Hour:00}_{date.Minute:00}_{date.Second:00}";
        }

        public static string ToFarsiFull(this DateTime date)
        {
            var pc = new PersianCalendar();
            return
                $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
        }

        private static readonly string[] Pn = {"۰", "۱", "۲", "۳", "۴", "۵", "۶", "۷", "۸", "۹"};
        private static readonly string[] En = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"};

        public static string ToEnglishNumber(this string strNum)
        {
            var cash = strNum;
            for (var i = 0; i < 10; i++)
                cash = cash.Replace(Pn[i], En[i]);
            return cash;
        }

        public static string ToPersianNumber(this int intNum)
        {
            var chash = intNum.ToString();
            for (var i = 0; i < 10; i++)
                chash = chash.Replace(En[i], Pn[i]);
            return chash;
        }

        public static DateTime? FromFarsiDate(this string InDate)
        {
            if (string.IsNullOrEmpty(InDate))
                return null;

            var spited = InDate.Split('/');
            if (spited.Length < 3)
                return null;

            if (!int.TryParse(spited[0].ToEnglishNumber(), out var year))
                return null;

            if (!int.TryParse(spited[1].ToEnglishNumber(), out var month))
                return null;

            if (!int.TryParse(spited[2].ToEnglishNumber(), out var day))
                return null;
            var c = new PersianCalendar();
            return c.ToDateTime(year, month, day, 0, 0, 0, 0);
        }


        public static DateTime ToGeorgianDateTime(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            try
            {
                var year = Convert.ToInt32(persianDate.Substring(0, 4));
                var month = Convert.ToInt32(persianDate.Substring(5, 2));
                var day = Convert.ToInt32(persianDate.Substring(8, 2));

                    return new DateTime(year, month, day, new PersianCalendar());
                
               
            }
            catch (Exception e)
            {
                return new DateTime(3000, 12, 20, new PersianCalendar());
            }
           
        }

        public static DateTime ToGeorgian(this string persianDate)
        {
            persianDate = persianDate.ToEnglishNumber();
            var year = Convert.ToInt32(persianDate.Substring(0, 4));
            var month = 01;
            var day = 01;
            return new DateTime(year, month, day, new PersianCalendar());
        }
        public static string ToMoney(this double myMoney)
        {
            return myMoney.ToString("N0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }
        public static string ToDoubleMoney(this string myMoney)
        {
            string bb = string.Empty;
           
                for (int x = 0; x < myMoney.Length; x++)
                {
                    if (char.IsDigit(myMoney[x]))
                        bb += myMoney[x];
                }

                if (bb.Length > 0)
                {
                    return bb;
                }
                else
                {
                    return "0";
                }
           

            
        }

        public static string ToFileName(this DateTime date)
        {
            return $"{date.Year:0000}-{date.Month:00}-{date.Day:00}-{date.Hour:00}-{date.Minute:00}-{date.Second:00}";
        }

        public static string FindeEndOfMonth(this string date)
        {
            string y2 = string.Empty;
            var year = Convert.ToInt32(date.Substring(0, 4));
            var month = Convert.ToInt32(date.Substring(5, 2));
            var YearD = date.Substring(0, 4);
            var MonthD = date.Substring(5, 2);
            if (month <= 6)
            {
                y2 = $"{YearD}/{MonthD}/31";
            }
            else if (month > 6 && month < 12)
            {
                y2 = $"{YearD}/{MonthD}/30";
            }
            else if (month == 12)
            {
                switch (year)
                {
                    case 1346:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1350:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1354:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1358:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1362:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1366:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1370:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1375:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1379:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1383:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1387:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1391:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1395:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1399:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1403:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1408:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1412:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1416:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1420:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1424:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1428:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1432:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1436:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1441:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;
                    case 1445:
                        y2 = $"{YearD}/{MonthD}/30";
                        break;

                    default:
                        y2 = $"{YearD}/{MonthD}/29";
                        break;

                }
            }

            return y2;
        }
    }
}