using GACore.Generics;
using NUnit.Framework;

namespace GACore.Test.Generics
{
	[TestFixture]
	[Category("Generics")]
	public class TLimit
	{
		[Test]
		public void Parameterless()
		{
			Limit<double> limit = new Limit<double>();

			Assert.AreEqual(0, limit.Minimum);
			Assert.AreEqual(0, limit.Maximum);

			limit.Maximum = 100;
			Assert.AreEqual(0, limit.Minimum);
			Assert.AreEqual(100, limit.Maximum);
		}

		[Test]
		[TestCase(0, 1)]
		public void Limit_Init(int min, int max)
		{
			Limit<int> limit = new Limit<int>(min, max);

			Assert.AreEqual(min, limit.Minimum);
			Assert.AreEqual(max, limit.Maximum);
		}

		[Test]
		public void Limit_Set_Maximum()
		{
			int maximum = 0;
			Limit<int> limit = new Limit<int>(int.MinValue, maximum);
			Assert.AreEqual(int.MinValue, limit.Minimum);
			Assert.AreEqual(maximum, limit.Maximum);

			maximum = int.MaxValue;
			limit.Maximum = maximum;
			Assert.AreEqual(int.MinValue, limit.Minimum);
			Assert.AreEqual(maximum, limit.Maximum);
		}

		[Test]
		public void Limit_Set_Minimum()
		{
			int minimum = int.MinValue;
			Limit<int> limit = new Limit<int>(minimum, int.MaxValue);
			Assert.AreEqual(minimum, limit.Minimum);
			Assert.AreEqual(int.MaxValue, limit.Maximum);

			minimum = 0;
			limit.Minimum = minimum;
			Assert.AreEqual(minimum, limit.Minimum);
			Assert.AreEqual(int.MaxValue, limit.Maximum);
		}
	}
}