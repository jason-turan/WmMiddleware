using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NB.DTC.Aptos.InventoryService.Domain
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
