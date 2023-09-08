using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userid;
            string password;
            Console.WriteLine("Enter userid:");
            userid = Console.ReadLine();
            password = displaypassword();
            if (userid == "kswetha" && password == "sweedeloitte")
            {
                Console.WriteLine("Successfully Logged In");
            }
            else
            {
                Console.WriteLine("No user with the given credentials");
            }
            Console.ReadLine();



        }
        static string displaypassword()
        {
            try
            {
                Console.WriteLine("Enter password:");
                string password = "";
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        password += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        else if (key.Key == ConsoleKey.Enter)
                        {
                            if (string.IsNullOrWhiteSpace(password))
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Empty value not allowed.");
                                displaypassword();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("");
                                break;
                            }
                        }
                    }
                } while (true);
                return password;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
