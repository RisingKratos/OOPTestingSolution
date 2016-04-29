using InterfacesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{ 

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
