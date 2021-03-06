﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Business.Managers;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Core;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business
{
    public class ProductManager : BaseManager<Product>, IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal) : base(productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList(null, x => x.Store, x => x.Store.Contractor);
        }

        public Product GetBy(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter, x => x.Store, x => x.Store.Contractor);
        }

        public List<Product> GetAllByPrice(Order order)
        {
            switch (order)
            {
                case Order.ASC:
                    return _productDal.GetList().OrderBy(x => x.Price).ToList();
                case Order.DESC:
                    return _productDal.GetList().OrderByDescending(x => x.Price).ToList();
                default:
                    return _productDal.GetList().OrderBy(x => x.Price).ToList();
            }
        }

        public List<Product> GetAllByStore(int storeId)
        {
            return _productDal.GetList().Where(x => x.Store.StoreId == storeId).ToList();
        }

        protected override ValidationResult Validate(Product t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}
