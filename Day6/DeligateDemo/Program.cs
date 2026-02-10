namespace DeligateDemo;

class Program
{
    static void Main(string[] args)
    {
        LinqDemo demo = new LinqDemo();
        demo.Run();
    }
}


// // Leacture 6 : Deligate in C# code

// namespace DelegatesDemo;


// public class OnclickEventArgs : EventArgs
// {
//     public string? ButtonName { get; set; }
// }

// //Publisher 

// public class Button
// {
//     public delegate void OnClickEventHandler();
//     public event OnClickEventHandler? OnClick;

//     public void Click()
//     {
//         OnClick?.Invoke();
//     }
// }


// class Program
// {
//     public static void Main(string[] args)
//     {
//         // DelegatesDemoApp app = new DelegatesDemoApp();
//         // // app.Run();
//         // app.HigherOrderFunctionDemo();
//         // app.LambdaExpressionDemo();
//         // app.AnonymousMethodDemo();

//         Button button = new Button();
//         button.OnClick += () => Console.WriteLine("Bell Rings!");
//         button.OnClick += () => Console.WriteLine("Electricity Bill Charged!");
//         button.OnClick += () => Console.WriteLine("Again Clicked!");

//         button.Click();
//     }
// }

// //void Add(int a, int b)
// // delegate void MathOperation(int a, int b);
// //int Add(int a, int b)
// //delegate int MathOperation(int a, int b);

// // Generic Delegate

// // delegate TResult GenericTwoParameterFunction<TFirst, TSecond, TResult>(TFirst a, TSecond b);

// //delegate void GenericTwoParameterAtion<TFirst, TSecond>(TFirst a, TSecond b);

// class DelegatesDemoApp
// {

//     public void HigherOrderFunctionDemo()
//     {
//         var result = CalculateArea(AreaOfRectangle);
//         var result2 = CalculateArea(AreaOfTriangle);
//         Console.WriteLine($"Area of Rectangle: {result}");
//         Console.WriteLine($"Area of Triangle: {result2}");
//     }

//     int CalculateArea(Func<int,int,int> areaFunction)
//     {
//         return areaFunction(5,10);
//     }

//     int AreaOfRectangle(int length, int width)
//     {
//         return length * width;
//     }

//     int AreaOfTriangle(int baseLength, int height)
//     {
//         return (baseLength * height) / 2;
//     }

//     // void PrintMessage(string message)
//     // {
//     //     Console.WriteLine(message);
//     // }

//     // bool IsEven(int number)
//     // {
//     //     return number % 2 == 0;
//     // }

//     // public void LambdaExpressionDemo()
//     // {
//     //     Func<int, int> f;

//     //     f= (int x) => x * x;
//     //     var result=f(5);
//     //     Console.WriteLine($"The square of 5 is: {result}");
//     // }

//     // public void AnonymousMethodDemo()
//     // {
//     //     MathOperation operation = delegate (int a, int b)
//     //     {
//     //         Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
//     //         return a + b;
//     //     };

//     //     operation(3, 4);
//     // }

//     // public void Run()
//     // {
//     //     // MathOperation operation = Add;
//     //     // GenericTwoParameterFunction<int, int, int> genericOperation = Add;
//     //     Func<int, int, int> genericOperation = Add;

//     //     Action<string> action = PrintMessage;
//     //     action("Hello from Action delegate!");

//     //     Predicate<int> predicate = IsEven;
//     //     int testNumber = 4;

//     //     Console.WriteLine($"Is {testNumber} even? {predicate(testNumber)}");


//     //     Func<string, string, string> stringOperation = Concatenate;

//     //     var x = stringOperation("Hello, ", "World!");
//     //     Console.WriteLine($"Concatenation result: {x}");

//     //     // Multicast delegate: adding more methods to the invocation list
//     //     genericOperation += Subtract;
//     //     genericOperation += Multiply;
//     //     genericOperation += Divide;

//     //     genericOperation -= Subtract; // Removing the Subtract method from the invocation list

//     //     var result = genericOperation(5, 3);
//     //     Console.WriteLine($"Final result: {result}");
//     // }

//     // public string Concatenate(string a, string b)
//     // {
//     //     string result = a + b;
//     //     Console.WriteLine($"Concatenating '{a}' and '{b}' results in: '{result}'");
//     //     return result;
//     // }

//     // public int Add(int a, int b)
//     // {
//     //     Console.WriteLine($"The sum of {a} and {b} is: {a + b}");
//     //     return a + b;
//     // }

//     // public int Subtract(int a, int b)
//     // {
//     //     Console.WriteLine($"The difference between {a} and {b} is: {a - b}");
//     //     return a - b;
//     // }

//     // public int Multiply(int a, int b)
//     // {
//     //     Console.WriteLine($"The product of {a} and {b} is: {a * b}");
//     //     return a * b;
//     // }

//     // public int Divide(int a, int b)
//     // {
//     //     if (b != 0)
//     //     {
//     //         Console.WriteLine($"The quotient of {a} and {b} is: {a / b}");
//     //         return a / b;
//     //     }
//     //     else
//     //     {
//     //         Console.WriteLine("Cannot divide by zero.");
//     //     }
//     //     return 0;
//     // }
// }


// // My Code 

// // using System;

// // namespace DeligateDemo

// // {   
// //    class Program
// //     {
// //         static void Main(string[] args)
// //         {
// //             DeligateDemo demo = new DeligateDemo();
// //             demo.Run();
// //         }
// //     }
    
// //     public class DeligateDemo
// //     {
// //          delegate int MathOperation(int a, int b);

// //          public void Run()
// //         {
// //             MathOperation operation =add;

// //             // Multicast Deligate : Adding more methods to invoke It
// //             operation += subtract;
// //             operation += Multiply;
// //             operation +=Division;

// //             var result=operation(10,5);
// //             Console.WriteLine("Result : "+ result);

// //         }

// //          public int add(int a, int b)
// //          {
// //              Console.WriteLine("Addition: " + (a + b));
// //              return a+b;
// //          }

// //          public int subtract(int a, int b)
// //          {
// //              Console.WriteLine("Subtraction: " + (a - b));
// //              return a-b;
// //          }

// //          public int Multiply(int a, int b)
// //          {
// //              Console.WriteLine("Multiply: " + (a * b));
// //              return a*b;
// //          }

// //          public int Division(int a, int b)
// //          {
// //              if (b == 0)
// //              {
// //                  Console.WriteLine("Cannot divide by zero.");
// //                  return 0; // or throw an exception
// //              }
// //              else {
// //              Console.WriteLine("Division: " + (a / b));
// //              return a/b;
// //              }
// //          }


       
// //         }
// //     }

