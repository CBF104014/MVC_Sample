using Sample.Cls;
using Sample.Interface;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Service
{
    public class MemberService : ICRUDService
    {
        MyDataBaseEntities MyEF = new MyDataBaseEntities();
        public dynamic Create(dynamic _Obj, dynamic _Para = null)
        {
            try
            {
                Member member = _Obj;
                MyEF.Members.Add(member);
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
            throw new NotImplementedException();
        }

        public dynamic Init(dynamic _Obj, dynamic _Para = null)
        {
            throw new NotImplementedException();
        }

        public dynamic Read(dynamic _Obj, dynamic _Para = null)
        {
            try
            {
                string UserId = _Obj.UserId;
                string Password = _Obj.Password;
                var Members = MyEF.Members.Where(x => x.UserId == UserId && x.Password == Password).ToList();
                return Members;
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

        public dynamic ReadAll()
        {
            try
            {
                var Members = MyEF.Members.Select(x => x).ToList();
                return Members;
            }
            catch (Exception ex)
            {
                return ReturnCode.Fail;
            }
        }
    }
}