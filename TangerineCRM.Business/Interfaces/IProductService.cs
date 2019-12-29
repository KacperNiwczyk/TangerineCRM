using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Interfaces
{
    public interface IProductService : IService<Product>
    {
        List<Product> GetAllByPrice(Order order);

        List<Product> GetAllByStore(int storeId);
    }
}
