﻿using System;
using TangerineCRM.Business;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Core.Contexts;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            DatabaseContext context = new DatabaseContext();
            ProductManager productManager = new ProductManager(new ProductDal(context));
            StoreManager storeManager = new StoreManager(new StoreDal(context));

            productManager.Add(new Product
            {
                ProductName = "Tangerines",
                Price = 50,
                ProductId = 1,
                Store = new Store()
                { Street = "test", Contractor = new Contractor() }
            });

            var store = storeManager.GetBy(x => x.StoreId == 1);

            var product = new Product() { ProductName = "Bananas", Store = store };

            productManager.Add(product);

            productManager.GetAll().ForEach(x => Console.WriteLine(x.ProductName + " " + x.Store.StoreId));

            Console.ReadLine();
        }
    }
}
