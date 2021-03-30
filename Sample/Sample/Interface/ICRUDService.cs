using Sample.Cls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Interface
{
    public interface ICRUDService
    {
        dynamic Init(dynamic _Obj, dynamic _Para = null);
        dynamic Create(dynamic _Obj, dynamic _Para = null);
        dynamic Read(dynamic _Obj, dynamic _Para = null);
        dynamic Update(dynamic _Obj, dynamic _Para = null);
        dynamic Delete(dynamic _Obj, dynamic _Para = null);
    }
}
