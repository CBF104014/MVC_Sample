using Sample.Cls;
using Sample.Interface;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Service
{
    public class ProductService : ICRUDService
    {
        MyDataBaseEntities MyEF = new MyDataBaseEntities();
        public dynamic Create(dynamic _Obj, dynamic _Para = null)
        {
            try
            {
                Product product = _Obj;
                MyEF.Products.Add(product);
                MyEF.SaveChanges();
                return ReturnCode.Success;
            }
            catch (Exception ex)
            {
                return ReturnCode.Fail;
            }
        }

        public dynamic Delete(dynamic _Obj, dynamic _Para = null)
        {
            try
            {
                Product product = _Obj;
                MyEF.Products.RemoveRange(MyEF.Products.Where(x => x.Pid == product.Pid));
                MyEF.SaveChanges();
                return ReturnCode.Success;
            }
            catch (Exception ex)
            {
                return ReturnCode.Fail;
            }
        }

        public dynamic Init(dynamic _Obj, dynamic _Para = null)
        {
            throw new NotImplementedException();
        }

        public dynamic Read(dynamic _Obj, dynamic _Para = null)
        {
            try
            {
                List<Product> products = MyEF.Products.Select(x => x).ToList();
                return products;
            }
            catch (Exception ex)
            {
                return ReturnCode.Fail;
            }
        }

        public dynamic Update(dynamic _Obj, dynamic _Para = null)
        {
            throw new NotImplementedException();
        }
    }
}