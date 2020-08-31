using System;
using System.Linq;

namespace test20200831
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new noteedgeContext();
            var cus = from c in db.TMember
                      select c;
            foreach(var c in cus)
            {
                System.Console.WriteLine(c.FAccount + "," + c.FPassword);
            }
        }
    }
}
