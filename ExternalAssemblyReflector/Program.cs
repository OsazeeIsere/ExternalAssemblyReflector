using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;//for fileNotFoundException definition
namespace ExternalAssemblyReflector
{
    class Program
    {
        public static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("Type in an assembly");
            Console.WriteLine("-> {0}", asm.FullName);
            Type[] types = asm.GetTypes();
            foreach(Type t in types)
            {
                Console.WriteLine($"Type: {t}");
                Console.WriteLine("");

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("External Assembly viewer");
            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("Enter an assembly to evaluate");
                Console.WriteLine("Or enter Q to quit:");

                //get name of assembly
                asmName = Console.ReadLine();

                //does user want to quit
                if (asmName.Equals("Q",StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                //try to load the assembly
                try
                {
                    // asm = Assembly.Load(asmName);
                    //to make the app more flexible, use loadfrom
                    //however you must supply the full path to the assembly
                    //C:\CarLibrary Version 2.2.0.0\CarLibrary.dll
                    asm = Assembly.LoadFrom(asmName);

                    DisplayTypesInAsm(asm);

                }
                catch
                {
                    Console.WriteLine("Sory can't find assembly");
                }

            } while (true);
            Console.ReadLine();

        }
    }
}
