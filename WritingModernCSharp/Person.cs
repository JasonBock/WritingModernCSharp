using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace WritingModernCSharp;

public sealed record Person(Guid Id, string Name, uint Age)
	: IAdditionOperators<Person, Person, Person>, IParsable<Person>
{
	public static Person operator +(Person a, Person b) =>
		new(Guid.NewGuid(), $"{a?.Name} {b?.Name}", 0);

	public static Person Parse(string s, IFormatProvider? provider)
	{
		ArgumentNullException.ThrowIfNull(s);
		var parts = s.Split(',');
		return new(Guid.Parse(parts[0]), parts[1], uint.Parse(parts[2], provider));
	}

	public static bool TryParse(string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out Person result)
	{
		ArgumentNullException.ThrowIfNull(s);
		var parts = s.Split(',');

		if (parts.Length == 3 &&
			Guid.TryParse(parts[0], out var id) &&
			uint.TryParse(parts[2], out var age))
		{
			result = new(id, parts[1], age);
			return true;
		}

		result = null;
		return false;
	}

	private string DescribeAge() =>
		this.Age switch
		{
			>= 0 and < 1 => "Infant",
			>= 1 and < 3 => "Toddler",
			>= 3 and < 13 => "Child",
			>= 13 and < 18 => "Adolescent",
			>= 18 and < 25 => "Young Adult",
			>= 25 and < 50 => "Adult",
			>= 50 and < 110 => "Wise",
			_ => "Immortal"
		};

	public override string ToString() =>
		$$"""
		Name: {{this.Name}},
		Id: {{this.Id}},
		Age: {{this.Age}} - {{this.DescribeAge()}}
		""";
}
