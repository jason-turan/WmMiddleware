using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Service.Inventory.Domain
{
    public interface IUnitOfWork<T>
    {
        void Execute(T model);
    }

    public interface IUnitOfWork<TModel,TReturn>
    {
        TReturn Execute(TModel model);
    }
}
