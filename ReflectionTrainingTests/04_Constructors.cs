using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionTrainingTests
{
	[TestClass]
	public class Constructors
	{
		public class Point
		{
			public double X { get; }
			public double Y { get; }

			public Point() : this(0, 0)
			{
			}

			public Point(double x, double y)
			{
				X = x;
				Y = y;
			}
		}

		[TestMethod]
		public void GetConstructorCount()
		{
			Type type = typeof(Point);

			int constructorCount = 0; // TODO: Find the number of constructors on the Point class
			
			Assert.AreEqual(2, constructorCount);
		}

		[TestMethod]
		public void CallPointConstructor()
		{
			Type type = typeof(Point);

			Point newPoint = null; // TODO: Use reflection to create a new point instance like new Point(1, 2)
			
			Assert.AreEqual(1, newPoint.X);
			Assert.AreEqual(2, newPoint.Y);
		}
	}
}