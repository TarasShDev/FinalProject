﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.EF;
using BLL.Interfaces;
using BLL.Services;
using DAL.Enteties;
using System.Data.Entity;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (EFUnitOfWork EF = new EFUnitOfWork("ServiceForTesting"))
            {
                
                
               
         
            }
            
            Console.WriteLine("finish");
            Console.Read();
        }
    }
}
