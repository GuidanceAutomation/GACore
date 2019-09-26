using NUnit.Framework;

namespace GACore.Extensions.Test
{
	[TestFixture]
	[Category("ExtensionMethods")]
	public class TGeneric_ExtensionMethods
	{
		[Test]
		[TestCase(1, -1, 0, 0)]
		public void Clamp(double value, double min, double max, double expected)
		{
			double actual = value.Clamp(min, max);
			Assert.AreEqual(expected, actual);
		}
	}
}
