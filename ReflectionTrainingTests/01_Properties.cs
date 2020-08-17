using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionTrainingTests
{
	[TestClass]
	public class Properties
	{ 
		public class Person
		{
			public string Name { get; set; }
			public int? Age { get; set; }
			public List<string> Nicknames { get; set; }

			public const string ConstantValue = "Magic!";
			public static string StaticValue { get; set;  } = "I'm a static value";

			private int HiddenValue { get; } = 123;
		}

		[TestMethod]
		public void FindPublicInstanceProperties()
		{
			Type type = typeof(Person);

			List<string> result = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name).ToList(); // TODO: Find all public instance methods of the person type

			Assert.That.ContainsSameElements(result, new[] {"Name", "Age", "Nicknames"});
		}

		[TestMethod]
		public void FindPrivateInstanceProperties()
		{
			Type type = typeof(Person);

			List<string> result = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic).Select(p => p.Name).ToList(); ; // TODO: Find all private instance methods of the person type

			Assert.AreEqual(1, result.Count);
			Assert.That.Contains(result, "HiddenValue");
		}

		[TestMethod]
		public void ReadPersonsName()
		{
			Person person = new Person { Name = "Arthur" };

			var prop = person.GetType().GetProperty("Name");
			string name = (string) prop.GetValue(person); // TODO: Read the name value from the person object

			Assert.AreEqual(person.Name, name);
		}

		[TestMethod]
		public void ReadPersonsAge()
		{
			Person person = new Person { Age = 42 };

			var prop = person.GetType().GetProperty("Age");
			int? age = (int)prop.GetValue(person); ; // TODO: Read the age value from the person object

			Assert.AreEqual(person.Age, age);
		}

		[TestMethod]
		public void ReadNicknames()
		{
			Person person = new Person {Nicknames = new List<string> {"Earthman", "Arthurian"}};

			var prop = person.GetType().GetProperty("Nicknames");

			List<string> nicknames = (List<string>)prop.GetValue(person); // TODO: Read the list of nicknames from the person object

			Assert.That.ContainsSameElements(person.Nicknames, nicknames);
		}

		[TestMethod]
		public void ReadHiddenValue()
		{
			Person person = new Person();

			var prop = person.GetType().GetProperty("HiddenValue", BindingFlags.Instance | BindingFlags.NonPublic);

			int? hiddenValue = (int)prop.GetValue(person); // TODO: Read the value of the HiddenValue property of the person object

			Assert.AreEqual(123, hiddenValue);
		}

		[TestMethod]
		public void SetPersonsAge()
		{
			Person person = new Person { Name = "Arthur" };

			var prop = person.GetType().GetProperty("Age");
			prop.SetValue(person, 42);
			
			// TODO: Set the age of the person to 42

			Assert.AreEqual(42, person.Age);
		}

		[TestMethod]
		public void ReadConstantValue()
		{
			Type type = typeof(Person);

			var prop = type.GetField("ConstantValue");

			string constantValue = (string)prop.GetValue(null);  // TODO: Read the ConstantValue from the person type

			Assert.AreEqual(Person.ConstantValue, constantValue);
		}

		[TestMethod]
		public void ReadStaticValue()
		{
			Type type = typeof(Person);

			var prop = type.GetProperty("StaticValue");

			string staticValue = (string) prop.GetValue(null);  // TODO: Read the StaticValue from the person type

			Assert.AreEqual(Person.StaticValue, staticValue);
		}

		[TestMethod]
		public void WriteStaticValue()
		{
			const string newStaticValue = "This is the new value";
			var prop = typeof(Person).GetProperty("StaticValue");
			prop.SetValue(null, newStaticValue);

			// TODO: Update the StaticValue on the person object to be the newStaticValue

			Assert.AreEqual(Person.StaticValue, newStaticValue);
		}
	}
}
