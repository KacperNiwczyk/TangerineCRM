using System;
using TangerineCRM.Business;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Business.Managers;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IProductService productManager = new ProductManager(new ProductDal());
            IStoreService store = new StoreManager(new StoreDal());

            productManager.Add(new Product { ProductName = "Tangerines", Price = 50, ProductId = 1, Store = new Store() { Address = new Address() { Street = "test"}, Contractor = new Contractor() } });

            productManager.GetAll().ForEach(x => Console.WriteLine(x.Store.Address.Street));

            Console.ReadLine();
        }
    }
}
