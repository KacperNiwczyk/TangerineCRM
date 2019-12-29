using System;
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
            productManager.Add(new Product { ProductName = "Tangerines", Price = 50, ProductId = 1, StoreID = 1 });

            foreach(var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        }
    }
}
