using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1No2
{
    public class Date
    {
        //поля
        private int Day;
        private int Month;
        private int Year;
        private double Difference;

        //свойства
        public int Day1
        {
            get { return Day; }
            set { Day = value; }
        }
        public int Month1
        {
            get { return Month; }
            set { Month = value; }
        }
        public int Year1
        {
            get { return Year; }
            set { Year = value; }
        }
        public double Difference1
        {
            get { return Difference; }
            set { Difference = value; }
        }

        //конструкторы
        public Date(int d, int m, int y)
        {
            Day1 = d;
            Month1 = m;
            Year1 = y;
        }
        public Date(int d, int m)
        {
            Day1 = d;
            Month1 = m;
            Year1 = 2016;
        }
        public Date()
        {
            Day1 = 1;
            Month1 = 1;
            Year1 = 2016;
        }
        public Date(string textdata)
        {
            string[] arraydata = textdata.Split('/');
            int d = Convert.ToInt16(arraydata[0]);
            int m = Convert.ToInt16(arraydata[1]);
            int y = Convert.ToInt16(arraydata[2]);
            Day1 = d;
            Month1 = m;
            Year1 = y;
        }

        //методы
        public string Output1()
        {
            return $"{Day1}/{Month1}/{Year1}";
        }
        public string Output2()
        {
            string[] nameofmonths = new string[12];
            nameofmonths[0] = "Январь";
            nameofmonths[1] = "Февраль";
            nameofmonths[2] = "Март";
            nameofmonths[3] = "Апрель";
            nameofmonths[4] = "Май";
            nameofmonths[5] = "Июнь";
            nameofmonths[6] = "Июль";
            nameofmonths[7] = "Август";
            nameofmonths[8] = "Сентябрь";
            nameofmonths[9] = "Октябрь";
            nameofmonths[10] = "Ноябрь";
            nameofmonths[11] = "Декабрь";

            int numofmonth = Month1 - 1;
            return $"{nameofmonths[numofmonth]},{Day1},{Year1}";
        }
        public string Output3()
        {
            string[] nameofmonths = new string[12];
            nameofmonths[0] = "January";
            nameofmonths[1] = "Februrary";
            nameofmonths[2] = "March";
            nameofmonths[3] = "April";
            nameofmonths[4] = "May";
            nameofmonths[5] = "June";
            nameofmonths[6] = "July";
            nameofmonths[7] = "August";
            nameofmonths[8] = "September";
            nameofmonths[9] = "October";
            nameofmonths[10] = "November";
            nameofmonths[11] = "December";

            int numofmonth = Month1 - 1;
            return $"{nameofmonths[numofmonth]},{Day1},{Year1}";
        }
        public bool IsLast()
        {
            if (Month1 == 1 || Month1 == 3 || Month1 == 5 || Month1 == 7 || Month1 == 8 || Month1 == 10 || Month1 == 12)
            {
                if (Day1 == 31)
                {
                    return true;
                }
            }
            if (Month1 == 4 || Month1 == 6 || Month1 == 9 || Month1 == 11)
            {
                if (Day1 == 30)
                {
                    return true;
                }
            }
            if (Year1 % 4 == 0)
            {
                if (Month1 == 2)
                {
                    if (Day1 == 29)
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (Month1 == 2)
                {
                    if (Day1 == 28)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Date NextDay()
        {
            Date nextDay = new Date();
            bool b = IsLast();
            if (!b)
            {
                nextDay.Day1 = Day1 + 1;
            }
            if (b)
            {
                if (Month1 != 12)
                {
                    nextDay.Day1 = 1; nextDay.Month1 = Month1 + 1;
                }
                if (Month1 == 12)
                {
                    nextDay.Day1 = 1; nextDay.Month1 = 1; nextDay.Year1 = Year1 + 1;
                }
            }
            return nextDay;
        }
        public Date PrevDay()
        {
            Date prevDay = new Date();
            if (Day1 != 1)
            {
                prevDay.Day1 = Day1 - 1;
            }
            if (Day1 == 1)
            {
                if (Month1 == 1)
                {
                    prevDay.Day1 = 31; prevDay.Month1 = 12; prevDay.Year1 = Year1 - 1;
                }
                if (Month1 == 5 || Month1 == 7 || Month1 == 10 || Month1 == 12)
                {
                    prevDay.Day1 = 30; prevDay.Month1 = Month1 - 1;
                }
                if (Month1 == 2 || Month1 == 4 || Month1 == 6 || Month1 == 8 || Month1 == 9 || Month1 == 11)
                {
                    prevDay.Day1 = 31; prevDay.Month1 = Month1 - 1;
                }
                if (Month1 == 3)
                {
                    if (Year1 % 4 == 0)
                    {
                        prevDay.Day1 = 29; prevDay.Month1 = 2;
                    }
                    else
                    {
                        prevDay.Day1 = 28; prevDay.Month1 = 2;
                    }
                }
            }
            return prevDay;
        }        
        public Date After(int n) 
        {
            DateTime firstDate = new DateTime(Year1, Month1, Day1);
            DateTime secondDate = firstDate.AddDays(n);
            Date newDate = new Date(secondDate.Day, secondDate.Month, secondDate.Year);
            return newDate;
        }
        public double Between(Date date2)
        {
            DateTime olddate = new DateTime(Year1, Month1, Day1);
            DateTime today = new DateTime(date2.Year1, date2.Month1, date2.Day1);
            Difference1 = (today - olddate).TotalDays;
            return Difference1;
        }
        
        //операторы
        public static bool operator !(Date data)
        {
            Date clData = new Date();
            bool b = clData.IsLast();
            if (b)
            {
                return false;
            }
            return true;
        }
        public static bool operator true(Date data)
        {
            if (data.Month1 == 1)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(Date data)
        {
            if (data.Month1 == 1)
            {
                return true;
            }
            return false;
        }
        public static bool operator &(Date data1, Date data2)
        {
            if (data1.Year1.Equals(data2.Year1))
            {
                if (data1.Month1.Equals(data2.Month1))
                {
                    if (data1.Day1.Equals(data2.Day1))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

        



        