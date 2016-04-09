using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string @namespace = "ConsoleApplication1";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == @namespace && t.GetInterfaces().Contains(typeof(IGetInfo))
                    select t;
            q.ToList().ForEach(t => 
            {
                IGetInfo x = (Activator.CreateInstance(t)) as IGetInfo;
                Console.WriteLine(x.GetInfo());
            });
            
        }
    }

    interface IGetInfo
    {
        string GetInfo();
    }

    public class A : IGetInfo
    {
        public string GetInfo()
        {
            return "1";
        }
    }

    public class B : IGetInfo
    {
        public string GetInfo()
        {
            return "2";
        }
    }

    public class C : IGetInfo
    {
        public string GetInfo()
        {
            return "3";
        }
    }

    public class D : IGetInfo
    {
        public string GetInfo()
        {
            return "4";
        }
    }

    public class E : IGetInfo
    {
        public string GetInfo()
        {
            return "5";
        }
    }

}
