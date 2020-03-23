using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using GACore.Architecture;

namespace GACore.Test
{
	[TestFixture]
	public class TKeyedEnumerable
	{
		[Test]
		public void Empty()
		{
			IKeyedEnumerable<int> empty = KeyedEnumerable<int>.Empty();

			Assert.AreEqual(Guid.Empty, empty.Key);
			CollectionAssert.IsEmpty(empty.Items);
		}

		[Test]
		public void ArgumentOutOfRange()
		{
			IEnumerable<int> values = new List<int>() { 0, 1, 2, 3 };
			Assert.Throws<ArgumentOutOfRangeException>(() => new KeyedEnumerable<int>(Guid.Empty, values));
		}

		[Test]
		public void Populated()
		{
			IEnumerable<int> values = new List<int>() { 0, 1, 2, 3 };

			IKeyedEnumerable<int> keyed = new KeyedEnumerable<int>(Guid.NewGuid(), values);

			Assert.AreNotEqual(Guid.Empty, keyed.Key);
			CollectionAssert.AreEqual(values, keyed.Items);
		}
	}
}
