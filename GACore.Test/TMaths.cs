using NUnit.Framework;

namespace GACore.Test
{
	[TestFixture]
	[Category("Maths")]
	public class TLinSpace
	{
		[Test]
		[TestCase(0, 1, 2, new double[] { 0, 1 })]
		[TestCase(1, 0, 2, new double[] { 1, 0 })]
		[TestCase(0, 1, 1, new double[] { 1 })]
		[TestCase(1, 0, 1, new double[] { 0 })]
		[TestCase(1, 0, 0, new double[] { })]
		public void LinSpace_Create(double x, double y, int n, double[] expected)
		{
			CollectionAssert.AreEqual(expected, GACore.Maths.LinSpace(x, y, n));
		}
	}
}