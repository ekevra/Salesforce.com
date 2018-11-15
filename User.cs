using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1No2
{
    public class User
    {
        //поля
        private string fam;
        private string login;
        private string password;
        private Date date;

        //свойства
        public string fam1
        {
            get { return fam; }
            set { fam = value; }
        }
        public string login1
        {
            get { return login; }
            set { login = value; }
        }
        public string password1
        {
            get { return password; }
            set { password = value; }
        }
        public Date date1
        {            
            get { return date; }
            set { date = value; }
        }

        //конструкторы
        public User()
        {
            this.fam = "Ivanov";
            this.login = "VanyaIvanov";
            this.password = "nmF9011";
            this.date = new Date("01/01/2016");
        }
        public User(string fam, string log, string pass, Date date)
        {
            this.fam = fam;
            this.login = log;
            this.password = pass;
            date1 = date;
        }
        public User(string fam, string log, string pass)
        {
            this.fam = fam;
            this.login = log;
            this.password = pass;

            Date date = new Date();
            date.Day1 = 2;
            date.Month1 = 2;
            date.Year1 = 2018;
        }

        //метод
        public void Output()
        {
            Console.WriteLine("Information about user:");
            Console.WriteLine("Surname: {0}",fam1);
            Console.WriteLine("Login:   {0}",login1);
            Console.WriteLine("Password:{0}",password1);
        }
    }
}
