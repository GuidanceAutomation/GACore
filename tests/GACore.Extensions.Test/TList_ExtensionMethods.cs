using GACore.Extensions.Test.TestObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TList_ExtensionMethods
	{
		[Test]
		[TestCase(3, 2)]
		public void GroupedList_CountDoubleGroup(int groupACount, int groupBCount)
		{
			int expectedCount = groupACount + groupBCount;
			int expectedGroups = (groupACount > 0 ? 1 : 0) + (groupBCount > 0 ? 1 : 0);

			List<AbstractFoo> sourceList = new List<AbstractFoo>();

			for (int i = 0; i < groupACount; i++) sourceList.Add(new FooA());

			for (int i = 0; i < groupBCount; i++) sourceList.Add(new FooB());

			Assert.AreEqual(sourceList.Count, expectedCount);
			Assert.AreEqual(sourceList.CountNextGroup(), groupACount);
			Assert.AreEqual(sourceList.CountTotalGroups(), expectedGroups);
		}

		[Test]
		public void GroupedList_CountSingleGroup()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>()
			{
				new FooA(), new FooA(), new FooA()
			};

			Assert.AreEqual(sourceList.Count, 3);
			Assert.AreEqual(sourceList.CountNextGroup(), 3);
			Assert.AreEqual(sourceList.CountTotalGroups(), 1);
		}

		[Test]
		public void GroupedList_CountTripleGroup()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>()
			{
				new FooA(), new FooA(), new FooA(),
				new FooB(), new FooB(),
				new FooA(), new FooA(), new FooA()
			};

			Assert.AreEqual(sourceList.Count, 8);
			Assert.AreEqual(sourceList.CountNextGroup(), 3);
			Assert.AreEqual(sourceList.CountTotalGroups(), 3);
		}

		[Test]
		public void GroupedList_DelistDoubleGroup()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>()
			{
				new FooA(), new FooA(),
				new FooB(), new FooB(), new FooB()
			};

			IList<AbstractFoo> delisted = sourceList.DelistGroup();

			Assert.AreEqual(sourceList.Count, 3);
			Assert.AreEqual(sourceList.CountNextGroup(), 3);
			Assert.AreEqual(sourceList.CountTotalGroups(), 1);
			Assert.AreEqual(delisted.Count, 2);
			Assert.AreEqual(delisted.CountNextGroup(), 2);
			Assert.AreEqual(delisted.CountTotalGroups(), 1);
		}

		[Test]
		public void GroupedList_Empty()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>();
			Assert.AreEqual(sourceList.CountNextGroup(), 0);
		}

		[Test]
		public void GroupedList_DelistEmpty()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>();

			Assert.AreEqual(sourceList.CountNextGroup(), 0);

			List<AbstractFoo> delisted = sourceList.DelistGroup();

			Assert.AreEqual(delisted.Count, 0);
			Assert.AreEqual(delisted.CountNextGroup(), 0);
		}

		[Test]
		public void GroupedList_DelistSingleGroup()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>()
			{
				new FooA(), new FooA()
			};

			List<AbstractFoo> delisted = sourceList.DelistGroup();

			Assert.AreEqual(sourceList.Count, 0);
			Assert.AreEqual(sourceList.CountNextGroup(), 0);

			Assert.AreEqual(delisted.Count, 2);
			Assert.AreEqual(delisted.CountNextGroup(), 2);
			Assert.AreEqual(delisted.CountTotalGroups(), 1);
		}

		[Test]
		public void GroupedList_DelistTripleGroup()
		{
			List<AbstractFoo> sourceList = new List<AbstractFoo>()
			{
				new FooA(),
				new FooA(),
				new FooB(),
				new FooB(),
				new FooB(),
				new FooA(),
				new FooA(),
			};

			Assert.AreEqual(sourceList.CountTotalGroups(), 3);

			List<AbstractFoo> delisted = sourceList.DelistGroup();

			Assert.AreEqual(sourceList.Count, 5);
			Assert.AreEqual(sourceList.CountNextGroup(), 3);
			Assert.AreEqual(sourceList.CountTotalGroups(), 2);

			Assert.AreEqual(delisted.Count, 2);
			Assert.AreEqual(delisted.CountNextGroup(), 2);
			Assert.AreEqual(delisted.CountTotalGroups(), 1);
		}
	}
}