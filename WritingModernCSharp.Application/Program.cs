using System.Globalization;
using System.Numerics;
using WritingModernCSharp;

Console.WriteLine("Creating two persons...");
Console.WriteLine();

var jane = new Person(Guid.NewGuid(), "Jane", 25);
var joe = new Person(Guid.NewGuid(), "Joe", 55);

Console.WriteLine(jane);
Console.WriteLine();
Console.WriteLine(joe);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Adding two persons...");
Console.WriteLine();

var janeJoe = Add(jane, joe);

Console.WriteLine(janeJoe);

var janeJoeAge = Add(jane.Age, joe.Age);
Console.WriteLine(janeJoeAge);

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Parsing a person...");
Console.WriteLine();

var parsedJohn = "e4185871-85e9-4eb6-846a-0e42720eaa0d,John,32";

if (Person.TryParse(parsedJohn, CultureInfo.CurrentCulture, out var john))
{
	Console.WriteLine(john);
}

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Creating older Jane...");
Console.WriteLine();

var olderJane = new Person(jane.Id, jane.Name, 55);

Console.WriteLine(olderJane);

var olderWitherJane = jane with { Age = 55 };
Console.WriteLine(olderWitherJane);

Console.WriteLine();
// Change this for collection expressions.
Console.WriteLine($"Average is : {Average(new Person[] { jane, joe })}");

static T Add<T>(T left, T right) where T : IAdditionOperators<T, T, T> => left + right;

static double Average(IEnumerable<Person> people) => people.Average(_ => _.Age);