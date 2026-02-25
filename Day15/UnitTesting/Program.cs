
add2and2theoutputshouldbe4(2,2);
add20and10theoutputshouldbe30(20,10);
add22and11theoutputshouldbe33(22,11);


void add2and2theoutputshouldbe4(int a, int b)
{   
    var Expected = 4;
    var result = Add(a, b);
    Console.WriteLine($"Expected Output: {Expected}, Actual Output: {result}");
    if (result != Expected)
    {
        Console.WriteLine("Test failed");
    }
    else
    {
        Console.WriteLine("Test passed");
    }
}

void add22and11theoutputshouldbe33(int a, int b)
{   
    var Expected = 33;
    var result = Add(a, b);
    Console.WriteLine($"Expected Output: {Expected}, Actual Output: {result}");
    if (result != Expected)
    {
        Console.WriteLine("Test failed");
    }
    else
    {
        Console.WriteLine("Test passed");
    }
}

void add20and10theoutputshouldbe30(int a, int b)
{   
    var Expected = 30;
    var result = Add(a, b);
    Console.WriteLine($"Expected Output: {Expected}, Actual Output: {result}");
    if (result != Expected)
    {
        Console.WriteLine("Test failed");
    }
    else
    {
        Console.WriteLine("Test passed");
    }
}

int Add(int x, int y)
{
    return x + y;
    // return 0;
}   