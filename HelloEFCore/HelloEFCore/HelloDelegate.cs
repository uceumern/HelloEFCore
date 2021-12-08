using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEFCore
{
    // rule of thumb: prefer Action and Func over custom delegates

    delegate void SimpleDelegate(); // same as Action
    delegate void DelegateWithParameter(string msg); // same as Action<string>
    delegate long CalcDelegate(int a, int b); // same as Func<int, int, long>

    internal class HelloDelegate
    {
        public HelloDelegate()
        {
            SimpleDelegate simpleDelegate = SimpleMethod;
            Action asAction = SimpleMethod;

            // call delegate:
            simpleDelegate.Invoke();
            // same:
            simpleDelegate();

            DelegateWithParameter delegateWithParameter = MethodWithParameter;
            delegateWithParameter?.Invoke("lolpatrol");
            delegateWithParameter = null;
            // nullcheck: will not be invoked when null
            delegateWithParameter?.Invoke("lolpatrol");
            // as Action
            Action<string> asActionWithParameter = MethodWithParameter;


            CalcDelegate calcDelegate = Add;
            Trace.WriteLine($"{calcDelegate?.Invoke(5, 6)}");
            // as Func
            Func<int, int, long> func = Add;

            // anonymous methods
            // old school
            Action actionAnon = delegate () { Trace.WriteLine("We are legion."); } ;
            
            // lambda operator
            Action actionAnon2 = () => { Trace.WriteLine("We are legion."); } ;
            Action actionAnon3 = () => Trace.WriteLine("We are legion.");

            // long form
            Action<string> actionAnonParameter = (string x) => Trace.WriteLine(x);
            // shorter, type can be skipped
            Action<string> actionAnonParameter2 = (x) => Trace.WriteLine(x);
            // even shorter, () can be skipped with a single parameter
            Action<string> actionAnonParameter3 = x => Trace.WriteLine(x);

            // long form
            Func<int, int, long> funcAnon = (int x, int y) => { return x + y; };
            // shorter, skip types
            Func<int, int, long> funcAnon2 = (x, y) => { return x + y; };
            // even shorter, implicit return
            Func<int, int, long> funcAnon3 = (x, y) => x + y;
        }

        void SimpleMethod()
        {
            Trace.WriteLine("Hello Delegate!");
        }

        void MethodWithParameter(string name)
        {
            Trace.WriteLine($"Hello Delegate: {name}!");
        }

        long Add(int x, int y)
        {
            return x + y;
        }
    }
}
