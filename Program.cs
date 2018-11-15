using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1No2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your login:");
            string login = Console.ReadLine();

            if (login.Length==0)
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); 
            }
            else
            {
                SignUp(login, ListOfUsers());
            }
            
            Console.ReadLine();
        } 
        
        
        public static void InputText(List<User> list, int n)
        {
            using (FileStream filestream = File.Open("list.txt", FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(filestream))
                for (int i = 0; i < n; i++)
                {
                    writer.WriteLine(list[i].fam1 + " " + list[i].login1 + " " + list[i].password1 + " " + list[i].date1.Output1());
                }
        }
        
        public static List<User> ListOfUsers()
        {
            List<User> listOfTextInformation = new List<User>();
            string textList = @"list.txt";
            StreamReader sr = new StreamReader(textList);

            int count = 0;
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line != null)
                    {
                        count++;
                    }
                }
            }
            string textList1 = @"list.txt";
            StreamReader ssr = new StreamReader(textList);
            using (ssr)//заполняет все данные без даты
                for (int i = 0; i < count; i++)
                {
                    string line = ssr.ReadLine();
                    string[] part = line.Split(' ');

                    User userI = new User(part[0], part[1], part[2]);

                    listOfTextInformation.Add(userI);
                }

            List<Date> listOfDates = new List<Date>();
            string textListt = @"list.txt";
            StreamReader srr = new StreamReader(textListt);
            using (srr)//запоминает даты
                for (int i = 0; i < count; i++)
                {
                    string line = srr.ReadLine();
                    string[] part = line.Split(' ');

                    Date date = new Date(part[3]);
                    
                    listOfDates.Add(date);
                }
            
            List<User> listOfUsers = new List<User>();
            for (int i = 0; i < listOfTextInformation.Count; i++)
            {
                User userI = new User(listOfTextInformation[i].fam1, listOfTextInformation[i].login1, listOfTextInformation[i].password1, listOfDates[i]);

                listOfUsers.Add(userI);
            }
            
            return listOfUsers;
        }
        
        public static void SignUp(string login, List<User> users)
        {
            int count = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].login1 == login)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("There isn't the same login. You should sign up.");
                
                Console.WriteLine("Input surname:");
                string newfam1 = Console.ReadLine();
                if (newfam1.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }
                Console.WriteLine("Input login:");
                string newlogin1 = Console.ReadLine();
                if (newlogin1.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }
                Console.WriteLine("Input password:");
                string newpassword1 = Console.ReadLine();
                if (newpassword1.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }
                Console.WriteLine("Input date(xx/xx/xxxx):");
                string newdate = Console.ReadLine();
                if (newdate.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }

                Date today = new Date(newdate);
                Console.WriteLine("The last day of using this password is: {0}/{1}/{2} .", today.After(90).Day1, today.After(90).Month1, today.After(90).Year1);

                User user = new User(newfam1, newlogin1, newpassword1, today);
                users.Add(user);
                InputText(users, users.Count);
            }
            if (count > 0)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].login1 == login)
                    {
                        Console.WriteLine("Input your password:");
                        string password = Console.ReadLine();
                        if (password.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }
                        if (users[i].password1 == password)
                        {
                            Console.WriteLine("Input today date(xx/xx/xxxx):");
                            string strdate = Console.ReadLine();
                            Date dateForPassword = new Date(strdate);
                            if (users[i].date1.Between(dateForPassword) >= 76 & users[i].date1.Between(dateForPassword) <= 89) 
                            {
                                Console.WriteLine("Diedline will be after : {0} days.", 
                                    90 - users[i].date1.Between(dateForPassword));
                            }
                            if (users[i].date1.Between(dateForPassword) >= 90)
                            {
                                Console.WriteLine("{0}, you should make new password.", users[i].fam1);
                                Console.WriteLine("Input new password:");
                                string newpass = Console.ReadLine();
                                if (newpass.Length == 0) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("String is empty!"); Console.ResetColor(); }
                                else {
                                    users[i].date1 = dateForPassword;
                                    users[i].password1 = newpass;
                                    Console.WriteLine("The last day of using this password is: {0}/{1}/{2} .", dateForPassword.After(90).Day1, dateForPassword.After(90).Month1, dateForPassword.After(90).Year1);
                                    InputText(users, users.Count);
                                }                              
                            }
                            if (users[i].date1.Between(dateForPassword) < 76)
                            {
                                Console.WriteLine("It's ok.");
                            }
                        }
                        else
                        { Console.WriteLine("Fake password."); }
                    }
                }                
            }
        }
    }
}
