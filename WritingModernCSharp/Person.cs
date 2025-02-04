using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingModernCSharp
{
	public sealed class Person
	{
		public Person(Guid id, string name, uint age)
		{
			this.Id = id;
			this.Name = name;
			this.Age = age;
		}

		public override string ToString()
		{
			return @$"Name: {this.Name},
Id: {this.Id},
Age: {this.Age} - {this.DescribeAge()}";
		}

		private string DescribeAge()
		{
			if (this.Age >= 0 && this.Age < 1)
			{
				return "Infant";
			}
			else if (this.Age >= 1 && this.Age < 3)
			{
				return "Toddler";
			}
			else if (this.Age >= 3 && this.Age < 13)
			{
				return "Child";
			}
			else if (this.Age >= 13 && this.Age < 18)
			{
				return "Adolescent";
			}
			else if (this.Age >= 18 && this.Age < 25)
			{
				return "Young Adult";
			}
			else if (this.Age >= 25 && this.Age < 50)
			{
				return "Adult";
			}
			else if (this.Age >= 50 && this.Age < 110)
			{
				return "Wise";
			}
			else
			{
				return "Immortal";
			}
		}

		public static Person Parse(string s)
		{
			var parts = s.Split(',');
			return new Person(Guid.Parse(parts[0]), parts[1], uint.Parse(parts[2]));
		}

		public static bool TryParse(string s, out Person result)
		{
			var parts = s.Split(',');

			if (parts.Length == 3 &&
				Guid.TryParse(parts[0], out var id) &&
				uint.TryParse(parts[2], out var age))
			{
				result = new Person(id, parts[1], age);
				return true;
			}

			result = null;
			return false;
		}

		public static Person operator +(Person a, Person b)
		{
			return new Person(Guid.NewGuid(), $"{a.Name} {b.Name}", 0);
		}

		public uint Age { get; set; }
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}