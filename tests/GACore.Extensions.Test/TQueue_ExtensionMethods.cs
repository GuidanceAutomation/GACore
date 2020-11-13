using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TQueue_ExtensionMethods
	{
		[Test]
		public void DequeueMatching()
		{
			Queue<int> queue = new Queue<int>();
			queue.EnqueueAll(new[] { 1, 2, 3, 4, 5, 6 });
			Assert.AreEqual(6, queue.Count);
			CollectionAssert.Contains(queue, 4);

			Assert.Throws(typeof(ArgumentOutOfRangeException), delegate { queue.DequeueMatching(i => i == 7); });
			var dequeued = queue.DequeueMatching(i => i == 4);

			Assert.AreEqual(4, dequeued);
			Assert.AreEqual(5, queue.Count);

			CollectionAssert.DoesNotContain(queue, 4);

			CollectionAssert.Contains(queue, 1);
			CollectionAssert.Contains(queue, 2);
			CollectionAssert.Contains(queue, 3);
			CollectionAssert.Contains(queue, 5);
			CollectionAssert.Contains(queue, 6);
		}
	}
}