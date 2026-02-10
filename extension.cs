Class Employee
{
    public int Id { get; set; }

    Public string FirstName { get; set; }

    Public string LastName { get; set; }
    Public int Age { get; set; }

}

public static class EmployeeExtensions
{
    public static string DoubleTheAge(this Employee x)
    {
        return (x.Age * 2).ToString();
    }
}