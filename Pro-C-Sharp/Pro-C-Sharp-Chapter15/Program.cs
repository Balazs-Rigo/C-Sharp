using System;
using System.Linq;
using System.Reflection;
using System.IO;

namespace Pro_C_Sharp_Chapter15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Late Binding *****");
            // Try to load a local copy of CarLibrary.
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            if (a != null)
                CreateUsingLateBinding(a);
            Console.ReadLine();
        }

        private static void ReflectOnAttributesUsingEarlyBinding()
        {
            // Get a Type representing the Winnebago.
            Type t = typeof(Winnebago);
            // Get all attributes on the Winnebago.
            object[] customAtts = t.GetCustomAttributes(false);
            // Print the description.
            foreach (VehicleDescriptionAttribute v in customAtts)
                Console.WriteLine("-> {0}\n", v.Description);
        }

        private static void ReflectAttributesUsingLateBinding()
        {
            try
            {
                // Load the local copy of AttributedCarLibrary.
                Assembly asm = Assembly.Load("AttributedCarLibrary");
                // Get type info of VehicleDescriptionAttribute.
                Type vehicleDesc = asm.GetType("AttributedCarLibrary.VehicleDescriptionAttribute");
                // Get type info of the Description property.
                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");
                // Get all types in the assembly.
                Type[] types = asm.GetTypes();
                // Iterate over each type and obtain any VehicleDescriptionAttributes.
                foreach (Type t in types)
                {
                    object[] objs = t.GetCustomAttributes(vehicleDesc, false);
                    // Iterate over each VehicleDescriptionAttribute and print
                    // the description using late binding.
                    foreach (object o in objs)
                    {
                        Console.WriteLine("-> {0}: {1}\n", t.Name, propDesc.GetValue(o, null));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                // Get metadata for the Minivan type.
                Type miniVan = asm.GetType("CarLibrary.MiniVan");
                // Create a Minivan instance on the fly.
                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Created a {0} using late binding!", obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n***** Types in Assembly *****");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
                Console.WriteLine("Type: {0}", t);
            Console.WriteLine("");
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("***** Methods *****");
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
            {
                // Get return type.
                string retVal = m.ReturnType.FullName;
                string paramInfo = "( ";
                // Get params.
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    paramInfo += string.Format("{0} {1} ", pi.ParameterType, pi.Name);
                }
                paramInfo += " )";
                // Now display the basic method sig.
                Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);
            }
            Console.WriteLine();
        }

        static void ListFields(Type t)
        {
            Console.WriteLine("***** Fields *****");
            var fieldNames = from f in t.GetFields() select f.Name;
            foreach (var name in fieldNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        // Display property names of type.
        static void ListProps(Type t)
        {
            Console.WriteLine("***** Properties *****");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
                Console.WriteLine("->{0}", name);
            Console.WriteLine();
        }

        // Display implemented interfaces.
        static void ListInterfaces(Type t)
        {
            Console.WriteLine("***** Interfaces *****");
            var ifaces = from i in t.GetInterfaces() select i;
            foreach (Type i in ifaces)
                Console.WriteLine("->{0}", i.Name);
        }

        // Just for good measure.
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("***** Various Statistics *****");
            Console.WriteLine("Base class is: {0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type a class type? {0}", t.IsClass);
            Console.WriteLine();
        }
    }
}
