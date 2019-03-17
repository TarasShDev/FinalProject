using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.EF;
using DAL.Enteties;
using System.Data.Entity;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (EFUnitOfWork EF = new EFUnitOfWork("ServiceForTesting"))
            {
                var q1 = EF.Tests.GetAll().First();
                Console.WriteLine($"{q1.Name} {q1.Description}");
            }
            
            Console.WriteLine("finish");
            Console.Read();
        }
    }
}
