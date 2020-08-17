using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionTrainingTests
{
	[TestClass]
	public class Fields
	{
		public class Point
		{
			public Point(double x, double y)
			{
				X = x;
				Y = y;
			}
			
			public readonly double X;
			public readonly double Y;
		}

		[TestMethod]
		public void ReadFieldNames()
		{
			Type type = typeof(Point);

			List<string> result = type.GetFields(BindingFlags.Instance | BindingFlags.Public).Select(p => p.Name).ToList(); // TODO: Find all public instance properties of the point type

			Assert.That.ContainsSameElements(result, new []{"X", "Y"});
		}

		[TestMethod]
		public void ReadFieldValue()
		{
			Point point = new Point(1, 2);

			double x = (double) point.GetType().GetField("X").GetValue(point);  // TODO: Read the X value from the point

			Assert.AreEqual(1, x);
		}
	}
}