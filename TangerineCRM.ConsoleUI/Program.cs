using System;
using TangerineCRM.Business;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

            ProductManager productManager = new ProductManager(new ProductDal());
            StoreManager storeManager = new StoreManager(new StoreDal());

            productManager.Add(new Product
            {
                ProductName = "Tangerines",
                Price = 50,
                ProductId = 1,
                Store = new Store()
                { Address = new Address() { Street = "test" }, Contractor = new Contractor() }
            });

            var store = storeManager.GetBy(x => x.StoreId == 1);

            var product = new Product() { ProductName = "Bananas", Store = store };

            productManager.Add(product);

            productManager.GetAll().ForEach(x => Console.WriteLine(x.ProductName + " " + x.Store.StoreId));

            Console.ReadLine();
        }
    }
}
