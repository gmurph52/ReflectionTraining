using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionTrainingTests
{
	[TestClass]
	public class Methods
	{
		public class Point
		{
			private static readonly Random _rand = new Random();
			
			public Point(double x, double y)
			{
				X = x;
				Y = y;
			}

			public readonly double X;
			public readonly double Y;

			public double DistanceTo(Point other)
			{
				return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
			}

			public static double DistanceBetween(Point a, Point b)
			{
				return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
			}

			private static Point GetRandomPoint()
			{
				return new Point(_rand.Next(), _rand.Next());
			}
		}
		
		[TestMethod]
		public void FindPublicInstanceMethodNames()
		{
			Type type = typeof(Point);

			List<string> result = type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Select(p => p.Name).ToList(); // TODO: Find all public instance methods of the Point type

			Assert.That.ContainsSameElements(result, new[] {"DistanceTo"});
		}

		[TestMethod]
		public void FindPublicStaticMethodNames()
		{
			Type type = typeof(Point);

			List<string> result = type.GetMethods(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public).Select(p => p.Name).ToList(); ; // TODO: Find all public static methods of the Point type

			Assert.That.ContainsSameElements(result, new[] {"DistanceBetween"});
		}

		[TestMethod]
		public void FindPrivateInstanceMethodNames()
		{
			Type type = typeof(Point);

			List<string> result = type.GetMethods(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.NonPublic).Select(p => p.Name).ToList(); // TODO: Find all private instance methods of the Point type

			Assert.That.ContainsSameElements(result, new[] {"GetRandomPoint"});
		}

		[TestMethod]
		public void CallDistanceToMethod()
		{
			Point point1 = new Point(0, 0);
			Point point2 = new Point(3, 4);

			double distance = (double)typeof(Point).GetMethod("DistanceTo").Invoke(point1, new object[] {point2}); // TODO: Use reflection to call point1.DistanceTo(point2)

			Assert.AreEqual(5, distance);
		}

		[TestMethod]
		public void CallDistanceBetweenMethod()
		{
			Point point1 = new Point(0, 0);
			Point point2 = new Point(3, 4);

			double distance = (double)typeof(Point).GetMethod("DistanceBetween", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[] { point1, point2 }); ; // TODO: Use reflection to call Point.DistanceBetween(point1, point2)

			Assert.AreEqual(5, distance);
		}

		[TestMethod]
		public void CallGetRandomPoint()
		{
			Point randomPoint = (Point) typeof(Point).GetMethod("GetRandomPoint", BindingFlags.NonPublic | BindingFlags.Static).Invoke(null, null); // TODO: Use reflection to call the private static method GetRandomPoint

			Assert.IsNotNull(randomPoint);
		}
	}
}