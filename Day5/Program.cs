using System;
using System.Collections;
using System.Collections.Generic;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generic Collection Demo:");
            collectionClassesDemo();

            Console.WriteLine("\nNon-Generic Collection Demo:");
            ArrayListDemo();
        }

        public static void collectionClassesDemo()
        {
            List<string> names = new List<string>();
            names.Add("Alice");
            names.Add("Bob");
            names.Add("Charlie");
            names.Add("rocky");
            names.Add("rocky");

            Console.WriteLine(names.Count);
            Console.WriteLine(names.Capacity);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        public static void ArrayListDemo()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.14);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

// using Microsoft.VisualBasic;
// using System;

// namespace Day5
// {
//     class Program
//     {

//         static void Swap<T>(ref T a, ref T b)// Generic method to swap two values
//     {
//         T temp = a;
//         a = b;
//         b = temp;
//     }
//         static void Main()
//         {
//             // GC demonstration
//             var res1 = new Resource("Res1"); // allocated on heap
//             var res2 = new Resource("Res2");

//             res1 = null;   // res1 now eligible for GC
//             res2 = res2;   // res2 still referenced

//             // Force garbage collection (normally automatic)
//             GC.Collect();
//             GC.WaitForPendingFinalizers();

//             Console.WriteLine("GC completed");

//             // -------- FileManager usage (existing code style) --------
//             using (FileManager fileManager = new FileManager())
//             {
//                 fileManager.OpenFile("test.txt");
//             }

//             Console.WriteLine("FileManager disposed properly");
//             // Console.ReadLine();


//             var temp1 =new Temp { Id=1, Name="Temp1"};
//             var temp2 = new Temp { Id=1, Name="Temp1" };

//             Console.WriteLine(temp1);
//             Console.WriteLine(temp2);
//             Console.WriteLine(temp1 == temp2); // True, because records compare by value

//             var temp3 = temp1 with { Id = 3}; //
//             Console.WriteLine(temp3);

//              int a = 5, b = 10;
//         Swap(ref a, ref b);
//         Console.WriteLine($"a={a}, b={b}");

//         string x = "A", y = "B";
//         Swap(ref x, ref y);
//         Console.WriteLine($"x={x}, y={y}");

//         }
//     }
// }
