using InterfacesLibrary;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{

    public static class Bootstrapper
    {
        //public static void SetupContainer(IUnityContainer container, List<IGetInfo> mappings)
        //{
        //    foreach(var mapping in mappings)
        //    {
        //        container.RegisterType<IGetInfo, mapping>();
        //        container.RegisterType(mapping.Interface, mapping.Type, mapping.Name);
        //    }
        //}
        internal static UnityContainer SetupContainer(UnityContainer container, IEnumerable<MyType> mappings)
        {
            foreach (var mapping in mappings)
            {
                container.RegisterType(mapping.Interface, mapping.Type, mapping.Name);
            }
            return container;
        }
    }
}
