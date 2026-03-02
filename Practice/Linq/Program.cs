using System;
using System.Collections.Generic;
using System.Linq;


var Students =new List<Students>
{
    new Students{ID=1,Name="John",Age=20},
    new Students{ID=2,Name="Jane",Age=22},
    new Students{ID=3,Name="Doe",Age=19},
    new Students{ID=4,Name="Smith",Age=21},
    new Students{ID=5,Name="Emily",Age=23}
};

var Results = Students.Where(s=>s.Age>20)
                .OrderBy(s=>s.Age)
                .Select(s=>new{
                    s.Name,
                    s.Age
                    }).ToList();
                    

foreach(var s in Results)
{
    Console.WriteLine(s);
}



class Students
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}

