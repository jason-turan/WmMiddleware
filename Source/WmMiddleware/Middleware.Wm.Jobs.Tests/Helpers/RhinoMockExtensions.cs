using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.Wm.Jobs.Tests.Helpers
{
    public static class RhinoMockExtensions
    {

        public static T Any<T>()
        {
            return Arg<T>.Is.Anything;
        }

        public static IList<T> AnyList<T>()
        {
            return Arg<IList<T>>.Is.Anything;
        }

        public static int AnyInt()
        {
            return Arg<int>.Is.Anything;
        }

        public static string AnyString()
        {
            return Arg<String>.Is.Anything;
        }

        public static void StubWithMethod<TFirstArgument, T, T2>(
            this T mockObject,
            Function<T, T2> accessorFunc,
            Func<TFirstArgument, object> func)
            where T : class
            where T2 : class
        {
            mockObject
                .Stub(accessorFunc)
                .Return(null)
                .WhenCalled(x =>
                {
                    var firstArg = (TFirstArgument)x.Arguments.First();
                    var toReturn = func(firstArg);
                    x.ReturnValue = toReturn;
                });
        }

        public static CaptureExpression<T> Capture<T>(this T stub)
        where T : class
        {
            return new CaptureExpression<T>(stub);
        }

        public static void CallbackAction<TMock, TArgument>(this IMethodOptions<TMock> mo, Action<TArgument> action)
        {
            mo.Callback((TArgument re) =>
             {
                 action(re);
                 return true;
             });
        }

    }
   
}
