using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapperClassGenerator
{
    public class SampleClass
    {
        
        public void Method0<TValue>()
        {
        }


        public void Method1<TValue>()
            where TValue : class
        {
        }

        public void Method2<TValue>()
            where TValue : struct
        {

        }

        public void Method3<TValue>()
            where TValue : IComparable
        {
        }

        public void Method4<TValue, TResult>()
            where TValue : class
            where TResult : TValue
        {
        }

        public void Method5<TValue>(Func<TValue> func)
            where TValue : IComparable
        {
        }

        public IEnumerable<TValue> Method6<TValue>(IEnumerable<TValue> func)
            where TValue : IComparable
        {
            throw new NotImplementedException();
        }

        public void Method7(string str, params Type[] types)
        {

        }

        public long Method8(ref Type[] types)
        {
            throw new NotImplementedException();
        }

        public string Method9(dynamic input)
        {
            throw new NotImplementedException();
        }

        public bool Method10(int input, out int result)
        {
            throw new NotImplementedException();
        }

        public bool Method11(Action<CustomPoint> invoker)
        {
            throw new NotImplementedException();
        }
    }
}
