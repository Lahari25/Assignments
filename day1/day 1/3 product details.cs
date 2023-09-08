using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string pid = "";
            string pname = "";
            int price = 0;
            int quantity = 0;
            int ta = 0;
            int fa = 0;
            int d = 0;
            Console.WriteLine("Provide Productid");
            pid=Console.ReadLine();
            Console.WriteLine("Provide Product Name");
            pname = Console.ReadLine();
            Console.WriteLine("Provide Unit Price");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Provide Quantity");
            quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Provide Total Amount");
            ta = int.Parse(Console.ReadLine());
            if (quantity > 10)
            {
                d = 0.1 * ta;
                fa = ta - d;
            }
             if (quantity > 30)
            {
                d = 0.2 * ta;
                fa = ta - d;
            }
            if (quantity > 50)
            {
                d = 0.3 * ta;
                fa = ta - d;
            }
            Console.WriteLine("Productid" + pid);
            Console.WriteLine("Product name"+ pname);
            Console.WriteLine("Unit Price"+  price);
            Console.WriteLine("Quantity"+ quantity);
            Console.WriteLine("Total Amount"+ ta);
            Console.WriteLine("Discount Amnount"+ d);
            Console.WriteLine("Final Amount"+ fa);



            Console.ReadLine();
        }
    }
}
