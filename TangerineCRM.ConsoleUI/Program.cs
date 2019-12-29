﻿using System;
using TangerineCRM.Business;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductService productManager = new ProductManager(new ProductDal());
            productManager.Add(new Product { ProductName = "Tangerines", Price = 50, ProductId = 1, Store = new Store() { Address = new Address(), Contractor = new Contractor() } });

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName + "\t" + product.Price + "\t" + product.StoreID);
            }

            Console.ReadLine();
        }
    }
}
