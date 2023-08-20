using NUnit.Framework;
using Rocks;

namespace WritingModernCSharp.Tests;

public static class PersonServiceTests
{
	[Test]
	public static void GetPersonWhenPersonExists()
	{
		var id = Guid.NewGuid();
		var person = new Person(id, "Jason", 21);

		var expectations = Rock.Create<IPersonRepository>();
		expectations.Methods().Retrieve(id).Returns(person);

		var mock = expectations.Instance();
		var service = new PersonService(mock);
		var servicePerson = service.Get(id);

		Assert.That(servicePerson, Is.EqualTo(person));
		expectations.Verify();
	}

	[Test]
	public static void GetPersonWhenPersonDoesNotExists()
	{
		var id = Guid.NewGuid();

		var expectations = Rock.Create<IPersonRepository>();
		expectations.Methods().Retrieve(id).Returns(null);

		var mock = expectations.Instance();
		var service = new PersonService(mock);
		var servicePerson = service.Get(id);

		Assert.That(servicePerson, Is.Null);
		expectations.Verify();
	}
}