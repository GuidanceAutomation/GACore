using MoreLinq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TIEnumerable_ExtensionMethods
	{
		/// <summary>
		/// Tests extension method to randomize an IEnumerable.
		/// </summary>
		[Test]
		public void IEnumerable_Randomize()
		{
			IEnumerable<double> refData = GenerateOrderedIEnumerable(100);
			IEnumerable<double> randomizedData = refData.Randomize();

			refData.ForEach(e => Assert.That(randomizedData.Contains(e)));

			Assert.AreNotEqual(refData, randomizedData);
		}

		private IEnumerable<double> GenerateOrderedIEnumerable(int numElements = 100)
		{
			List<double> dataSet = new List<double>();

			for (int i = 0; i < numElements; i++) dataSet.Add(i);

			return dataSet;
		}
	}
}