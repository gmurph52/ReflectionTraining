using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionTrainingTests
{
	public static class AssertExtensions
	{
		public static void Contains<T>(this Assert assert, IEnumerable<T> list, T item)
		{
			if (list == null)
			{
				Assert.Fail("No items in list");
			}

			if (item == null)
			{
				Assert.Fail("Item to search for is null");
			}

			if (!list.Any(i => item.Equals(i)))
			{
				Assert.Fail("List does not contain the item: " + item);
			}
		}

		public static void ContainsSameElements<T>(this Assert assert, IEnumerable<T> list1, IEnumerable<T> list2)
		{
			if (list1.Count() != list2.Count() || !list1.All(x => list2.Any(y => x.Equals(y))))
			{
				Assert.Fail("The two lists do not contain the same items");
			}
		}
	}
}