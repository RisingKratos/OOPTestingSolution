using InterfacesLibrary;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class MyType
    {
        public Type Interface { get; set; }
        public Type Type { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var container = new UnityContainer();

            var requiredInterfaces = new[]
            {
                typeof(IGetInfo)
            };

            var implementationAssemblies = Directory.GetFiles(@"D:\DLLs\","*.dll");

            var mappings = from assemblyName in implementationAssemblies
                           from type in Assembly.LoadFile(assemblyName).GetTypes()
                           from requiredInterface in requiredInterfaces
                           where requiredInterface.IsAssignableFrom(type)
                           select new MyType
                           {
                               Interface = requiredInterface,
                               Type = type,
                               Name = type.Name,
                               FullName = type.FullName
                           };
            //List<IGetInfo> myMappings = null;
            container = Bootstrapper.SetupContainer(container, mappings);
            foreach (var mapping in mappings.ToList())
            {
            //    myMappings.Add(mapping.Type as IGetInfo);
            //  container.RegisterType(mapping.Interface, mapping.Type, mapping.Name);
            }
            //Bootstrapper.SetupContainer(container, myMappings);
            //var y = container.Resolve<IGetInfo> ("A");
            while (true)
            {
                string x = Console.ReadLine();
                var myIGetInfoClass = container.Resolve<IGetInfo>(x);
                Console.WriteLine(myIGetInfoClass.GetInfo());
            }

            //string folder = @"D:\DLLs";1
            //var files = Directory.GetFiles(folder, "*.dll");

            //foreach (var file in files)
            //{
            //    var catcher = Assembly.LoadFile(file);
            //    var q = from t in catcher.GetTypes()
            //            where t.IsClass && t.GetInterfaces().Contains(typeof(IGetInfo))
            //            select t;
            //    q.ToList().ForEach(t =>
            //    {
            //        Console.WriteLine(t.Name);
            //        IGetInfo x = (Activator.CreateInstance(t)) as IGetInfo;
            //        Console.WriteLine(x.GetInfo());
            //    });
            //}

            //container.Resolve<>();
        }
    }
}
