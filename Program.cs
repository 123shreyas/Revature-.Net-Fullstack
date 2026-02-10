using System;

class Program
{
    static void ChangeValue(ref int x)
    {
        x = 100;
    }

    static void Main()
    {
        int a = 10;
        ChangeValue(ref a);
        Console.WriteLine(a);
    }
}
